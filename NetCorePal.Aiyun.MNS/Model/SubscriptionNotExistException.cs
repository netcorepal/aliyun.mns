/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// MalformedXMLException
    /// </summary>
    public class SubscriptionNotExistException : MNSException
    {
        /// <summary>
        /// Constructs a new SubscriptionNotExistException with the specified error message.
        /// </summary>
        public SubscriptionNotExistException(string message)
            : base(message)
        { }

        public SubscriptionNotExistException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public SubscriptionNotExistException(Exception innerException)
            : base(innerException)
        { }

        public SubscriptionNotExistException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public SubscriptionNotExistException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
