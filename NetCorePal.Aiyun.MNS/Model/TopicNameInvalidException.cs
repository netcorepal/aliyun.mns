/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// MessageNotExistException
    /// </summary>
    public class TopicNameInvalidException : MNSException
    {
        /// <summary>
        /// Constructs a new MessageNotExistException with the specified error message.
        /// </summary>
        public TopicNameInvalidException(string message)
            : base(message)
        { }

        public TopicNameInvalidException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public TopicNameInvalidException(Exception innerException)
            : base(innerException)
        { }

        public TopicNameInvalidException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public TopicNameInvalidException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
