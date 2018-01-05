/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// TopicAlreadyExistException
    /// </summary>
    public class TopicAlreadyExistException : MNSException
    {
        /// <summary>
        /// Constructs a new TopicAlreadyExistException with the specified error message.
        /// </summary>
        public TopicAlreadyExistException(string message)
            : base(message)
        { }

        public TopicAlreadyExistException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public TopicAlreadyExistException(Exception innerException)
            : base(innerException)
        { }

        public TopicAlreadyExistException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public TopicAlreadyExistException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
