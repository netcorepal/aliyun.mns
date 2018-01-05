/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// EndpointInvalidException
    /// </summary>
    public class EndpointInvalidException : MNSException
    {
        /// <summary>
        /// Constructs a new EndpointInvalidException with the specified error message.
        /// </summary>
        public EndpointInvalidException(string message)
            : base(message)
        { }

        public EndpointInvalidException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public EndpointInvalidException(Exception innerException)
            : base(innerException)
        { }

        public EndpointInvalidException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public EndpointInvalidException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
