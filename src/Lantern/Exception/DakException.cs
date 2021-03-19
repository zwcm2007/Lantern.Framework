using System;
using System.Runtime.Serialization;

namespace Lantern
{
    /// <summary>
    /// Base exception type for those are thrown by Abp system for Abp specific exceptions.
    /// </summary>
    [Serializable]
    public class DakException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="DakException"/> object.
        /// </summary>
        public DakException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="DakException"/> object.
        /// </summary>
        public DakException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="DakException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public DakException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="DakException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public DakException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
