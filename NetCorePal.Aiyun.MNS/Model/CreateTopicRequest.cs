/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS CreateTopic service.
    /// </summary>
    public partial class CreateTopicRequest : MNSRequest
    {
        private string _topicName;
        private TopicAttributes _attributes = new TopicAttributes();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public CreateTopicRequest() { }

        /// <summary>
        /// Instantiates CreateTopicRequest with the parameterized properties
        /// </summary>
        /// <param name="queueName">The name for the topic to be created.</param>
        /// <param name="attributes">The queue attributes to be set.</param>
        public CreateTopicRequest(string topicName, TopicAttributes attributes)
        {
            _topicName = topicName;
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

        /// <summary>
        /// Gets and sets the property TopicName. 
        /// </summary>
        public string TopicName
        {
            get { return this._topicName; }
            set { this._topicName = value; }
        }

        // Check to see if TopicName property is set
        internal bool IsSetTopicName()
        {
            return this._topicName != null;
        }
    }
}