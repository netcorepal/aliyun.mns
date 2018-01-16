/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS SetQueueAttributes service.
    /// </summary>
    public partial class SetQueueAttributesRequest : SimpleMNSRequest
    {
        private QueueAttributes _attributes = new QueueAttributes();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SetQueueAttributesRequest() { }

        /// <summary>
        /// Instantiates SetQueueAttributesRequest with the parameterized properties
        /// </summary>
        /// <param name="attributes">The queue attributes to set.</param>
        public SetQueueAttributesRequest(QueueAttributes attributes)
        {
            _attributes = attributes;
        }

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
