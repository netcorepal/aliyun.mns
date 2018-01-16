/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS SetTopicAttributes service.
    /// </summary>
    public partial class SetTopicAttributesRequest : SimpleMNSRequest
    {
        private TopicAttributes _attributes = new TopicAttributes();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SetTopicAttributesRequest() { }

        /// <summary>
        /// Instantiates SetTopicAttributesRequest with the parameterized properties
        /// </summary>
        /// <param name="attributes">The topic attributes to set.</param>
        public SetTopicAttributesRequest(TopicAttributes attributes)
        {
            _attributes = attributes;
        }

        /// <summary>
        /// Gets and sets the property Attributes.
        /// </summary>
        public TopicAttributes Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
        }

    }
}
