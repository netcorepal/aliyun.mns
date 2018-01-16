/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using System.Net;

namespace Aliyun.MNS.Model
{
    ///<summary>
    /// QueueAlreadyExistException
    /// </summary>
    public class QueueAlreadyExistException : MNSException 
    {
        /// <summary>
        /// Constructs a new QueueAlreadyExistException with the specified error message.
        /// </summary>
        public QueueAlreadyExistException(string message) 
            : base(message) {}
          
        public QueueAlreadyExistException(string message, Exception innerException) 
            : base(message, innerException) {}
            
        public QueueAlreadyExistException(Exception innerException) 
            : base(innerException) {}

        public QueueAlreadyExistException(string message, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, errorCode, requestId, hostId, statusCode) { }

        public QueueAlreadyExistException(string message, Exception innerException, string errorCode, string requestId, string hostId, HttpStatusCode statusCode)
            : base(message, innerException, errorCode, requestId, hostId, statusCode) { }
    }
}
