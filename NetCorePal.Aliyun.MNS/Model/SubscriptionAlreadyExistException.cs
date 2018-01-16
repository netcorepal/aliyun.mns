/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// SubscriptionAlreadyExistException
    /// </summary>
    public class SubscriptionAlreadyExistException : MNSException
    {
        /// <summary>
        /// Constructs a new SubscriptionAlreadyExistException with the specified error message.
        /// </summary>
        public SubscriptionAlreadyExistException(string message)
            : base(message)
        { }

        public SubscriptionAlreadyExistException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public SubscriptionAlreadyExistException(Exception innerException)
            : base(innerException)
        { }

        public SubscriptionAlreadyExistException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public SubscriptionAlreadyExistException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
