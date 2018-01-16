/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS CreateQueue service
    /// </summary>
    public partial class CreateQueueResponse : WebServiceResponse
    {
        private string _queueUrl;

        /// <summary>
        /// Gets and sets the property QueueUrl. 
        /// </summary>
        public string QueueUrl
        {
            get { return this._queueUrl; }
            set { this._queueUrl = value; }
        }

        // Check to see if QueueUrl property is set
        internal bool IsSetQueueUrl()
        {
            return this._queueUrl != null;
        }
    }
}