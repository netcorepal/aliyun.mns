/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// SubscriptionNameLengthErrorException
    /// </summary>
    public class SubscriptionNameLengthErrorException : MNSException
    {
        /// <summary>
        /// Constructs a new SubscriptionNameLengthErrorException with the specified error message.
        /// </summary>
        public SubscriptionNameLengthErrorException(string message)
            : base(message)
        { }

        public SubscriptionNameLengthErrorException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public SubscriptionNameLengthErrorException(Exception innerException)
            : base(innerException)
        { }

        public SubscriptionNameLengthErrorException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode)
        { }

        public SubscriptionNameLengthErrorException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode)
        { }
    }
}
