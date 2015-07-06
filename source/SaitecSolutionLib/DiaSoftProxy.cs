using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;
using System.Collections;

namespace SaitecSolutionLib
{
    /// <summary>
    /// A proxy class which implement RealProxy class.
    /// it's create Remote side proxy.
    /// </summary>
    [CLSCompliant(true)]
    public class DiaSoftProxy : RealProxy
    {
        MarshalByRefObject _targetTcp, _targetHttp;
        Type _serverType;
        string _TcpUrl;
        string _HttpUrl;
        ObjRef objRef;
        IMessageSink[] _messageSinks;

        #region Constructor
        /// <summary>
        /// Parameteraize Constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        public DiaSoftProxy(Type type, MarshalByRefObject target)
            : base(type)
        {
            _serverType = type;
            BuildTcpURL(RemotingServices.GetObjectUri((MarshalByRefObject)target));
            BuildHttpURL(RemotingServices.GetObjectUri((MarshalByRefObject)target));
            _targetTcp = target;
            _targetHttp = (MarshalByRefObject)Activator.GetObject(type, _HttpUrl);

            objRef = RemotingServices.Marshal(target);
            _messageSinks = GetMessageSinks();
        }
        /// <summary>
        /// Parameteraize Constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        public DiaSoftProxy(Type type, string url)
            : base(type)
        {
            _serverType = type;
            BuildTcpURL(url);
            BuildHttpURL(url);
            _targetTcp = (MarshalByRefObject)Activator.GetObject(type, _TcpUrl);
            _targetHttp = (MarshalByRefObject)Activator.GetObject(type, _HttpUrl);
            _messageSinks = GetMessageSinks();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets target object that uses tcp connection.
        /// </summary>
        public ObjRef GetObjRef
        {
            get { return objRef; }
        }
        #endregion

        #region Methods
        public override IMessage Invoke(IMessage msg)
        {
            Exception InnerException;
            msg.Properties["__Uri"] = _TcpUrl;
            IMessage retMsg = _messageSinks[0].SyncProcessMessage(msg);
            // Handle construction call message differently than other method
            // call messages.
            if (msg is IConstructionCallMessage)
            {
                // need to finish CAO activation manually.
                string url = GetUrlForCAO(_serverType);
                if (url.Length > 0)
                {
                    ActivatedCAO((IConstructionCallMessage)msg, url);
                }

                IConstructionReturnMessage crm = EnterpriseServicesHelper.CreateConstructionReturnMessage((IConstructionCallMessage)msg, (MarshalByRefObject)this.GetTransparentProxy());
                return crm;
            }
            else
            {
                if (retMsg is IMethodReturnMessage)
                {
                    IMethodReturnMessage mrm = (IMethodReturnMessage)retMsg;
                    if (mrm.Exception == null) return retMsg;
                    else InnerException = mrm.Exception;
                }
                else
                {
                    MethodCallMessageWrapper mcm = new MethodCallMessageWrapper((IMethodCallMessage)msg);
                    mcm.Uri = RemotingServices.GetObjectUri((MarshalByRefObject)_targetTcp);
                    return RemotingServices.GetEnvoyChainForProxy((MarshalByRefObject)_targetTcp).SyncProcessMessage(msg);
                }
                msg.Properties["__Uri"] = _HttpUrl;
                retMsg = _messageSinks[1].SyncProcessMessage(msg);
                if (retMsg is IMethodReturnMessage)
                {
                    IMethodReturnMessage mrm = (IMethodReturnMessage)retMsg;
                }
                return retMsg;
            }
        }

        private IMessageSink[] GetMessageSinks()
        {
            IChannel[] registeredChannels = ChannelServices.RegisteredChannels;
            IMessageSink MessageSink;
            string ObjectURI;
            ArrayList MessageSinks = new ArrayList();

            foreach (IChannel channel in registeredChannels)
            {
                if (channel is IChannelSender)
                {
                    IChannelSender channelSender = (IChannelSender)channel;
                    if (channelSender.ChannelName == "tcp")
                        MessageSink = channelSender.CreateMessageSink(_TcpUrl, null, out ObjectURI);
                    else
                        MessageSink = channelSender.CreateMessageSink(_HttpUrl, null, out ObjectURI);
                    if (MessageSink != null) MessageSinks.Add(MessageSink);
                }
            }
            //string objectURI;
            //HttpChannel HttpChannel = new HttpChannel();
            //ChannelServices.RegisterChannel(HttpChannel, false);
            //MessageSinks.Add(HttpChannel.CreateMessageSink(_HttpUrl, null, out objectURI));

            if (MessageSinks.Count > 0)
            {
                return (IMessageSink[])MessageSinks.ToArray(typeof(IMessageSink));
            }
            // Made it out of the foreach block without finding
            // a MessageSink for the URL.
            throw new Exception("Unable to find MessageSink for the URL :" + _TcpUrl);
        }

        private void BuildHttpURL(string _Url)
        {
            UriBuilder uBuilder = new UriBuilder(_Url);
            //uBuilder.Port = 8086;
            uBuilder.Scheme = "http";
            //uBuilder.Host = "Soft2";
            uBuilder.Path = "DiaSoft" + uBuilder.Path;
            _HttpUrl = uBuilder.ToString();
        }

        private void BuildTcpURL(string _Url)
        {
            string _strTCPPort = System.Configuration.ConfigurationSettings.AppSettings["TCPPort"];
            if (_strTCPPort == null || _strTCPPort.Trim() == "")
                _strTCPPort = "8085";
            UriBuilder uBuilder = new UriBuilder(_Url);
            uBuilder.Port = int.Parse(_strTCPPort);
            uBuilder.Scheme = "tcp";
            _TcpUrl = uBuilder.ToString();
        }

        private void ActivatedCAO(IConstructionCallMessage ccm, string url)
        {
            // Connect to remote activation service.
            string rem = url + @"/RemoteActivationService.rem";
            IActivator remActivator = (IActivator)RemotingServices.Connect(typeof(IActivator), rem);
            IConstructionReturnMessage crm = remActivator.Activate(ccm);

            //
            // The return message's ReturnValue property is the ObjRef for
            // the remote object. We need to unmarshal it into a local proxy
            // to which we forward messages.
            ObjRef objRef = (ObjRef)crm.ReturnValue;
            _targetTcp = (MarshalByRefObject)RemotingServices.Unmarshal(objRef);
        }

        string GetUrlForCAO(Type type)
        {
            string s = "";
            ActivatedClientTypeEntry[] act = RemotingConfiguration.GetRegisteredActivatedClientTypes();

            foreach (ActivatedClientTypeEntry acte in act)
            {
                if (acte.ObjectType == type)
                {
                    s = acte.ApplicationUrl;
                    break;
                }
            }
            return s;
        }
        #endregion
    }
}
