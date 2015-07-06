using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SaitecSolutionLib
{
    [CLSCompliant(true)]
    [Serializable]
    public class Error
    {

        #region Declare Varible
        private IDictionary data;
        private string helpLink;
        private Error innerError;
        private string message;
        private string source;
        private string trace;
        private MethodBase targetSite;
        #endregion

        #region Constructor
        public Error(Exception e)
        {
            data = e.Data;
            helpLink = e.HelpLink;
            if (e.InnerException != null) innerError = new Error(e.InnerException);
            message = "DiaSoftLib-*#06# : " + e.Message;
            source = e.Source;
            trace = e.StackTrace;
            targetSite = e.TargetSite;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a collection of key/values pairs that provide additional, user-defined information about error.
        /// </summary>
        public IDictionary Data
        {
            get { return data; }
        }
        /// <summary>
        /// Gets or sets a link to the help file associated with this error.
        /// </summary>
        public string HelpLink
        {
            get { return helpLink; }
            set { helpLink = value; }
        }
        /// <summary>
        /// Gets the DiaSoftPOC.Error instance that cause this error.
        /// </summary>
        public Error InnerError
        {
            get { return innerError; }
        }
        /// <summary>
        /// Gets a message that describes the current error.
        /// </summary>
        public string Message
        {
            get { return message; }
        }
        /// <summary>
        /// Gets or sets the name of the application or object that cause the error.
        /// </summary>
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        /// <summary>
        /// Gets a string representation of a frames on the call stack at the time when current error occurs.
        /// </summary>
        public string StackErrorTrace
        {
            get { return trace; }
        }
        /// <summary>
        /// Gets the method that cause the current error.
        /// </summary>
        public MethodBase TargetSite
        {
            get { return targetSite; }
        }
        #endregion
    }
}
