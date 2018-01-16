/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// QueueNotExistException
    /// </summary>
    public class TopicNameLengthErrorException : MNSException
    {
        /// <summary>
        /// Constructs a new QueueNotExistException with the specified error message.
        /// </summary>
        public TopicNameLengthErrorException(string message)
            : base(message)
        { }

        public TopicNameLengthErrorException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public TopicNameLengthErrorException(Exception innerException)
            : base(innerException)
        { }

        public TopicNameLengthErrorException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public TopicNameLengthErrorException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
