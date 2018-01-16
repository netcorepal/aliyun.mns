/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// SubscriptionNameInvalidException
    /// </summary>
    public class SubscriptionNameInvalidException : MNSException
    {
        /// <summary>
        /// Constructs a new SubscriptionNameInvalidException with the specified error message.
        /// </summary>
        public SubscriptionNameInvalidException(string message)
            : base(message)
        { }

        public SubscriptionNameInvalidException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public SubscriptionNameInvalidException(Exception innerException)
            : base(innerException)
        { }

        public SubscriptionNameInvalidException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public SubscriptionNameInvalidException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
