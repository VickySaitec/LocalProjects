using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaitecSolutionLib
{
    [CLSCompliant(true)]
    [Serializable]
    public class InformationException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InformationException() : base() { }
        /// <summary>
        /// Initializes with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InformationException(string message) : base(message) { }
        /// <summary>
        /// Initializes with a specified error 
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.
        /// </param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// If the innerException parameter is not a null reference, the current exception 
        /// is raised in a catch block that handles the inner exception.
        /// </param>
        public InformationException(string message, Exception exception) : base(message, exception) { }
        /// <summary>
        /// Initializes with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public InformationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    [CLSCompliant(true)]
    [Serializable]
    public class WarningException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WarningException() : base() { }
        /// <summary>
        /// Initializes with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public WarningException(string message) : base(message) { }
        /// <summary>
        /// Initializes with a specified error 
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.
        /// </param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// If the innerException parameter is not a null reference, the current exception 
        /// is raised in a catch block that handles the inner exception.
        /// </param>
        public WarningException(string message, Exception exception) : base(message, exception) { }
        /// <summary>
        /// Initializes with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public WarningException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
