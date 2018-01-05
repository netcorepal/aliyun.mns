/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS GetQueueAttributes service
    /// </summary>
    public partial class GetQueueAttributesResponse : WebServiceResponse
    {
        private QueueAttributes _attributes = new QueueAttributes();

        /// <summary>
        /// Gets and sets the property Attributes. 
        /// </summary>
        public QueueAttributes Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
        }
    }
}