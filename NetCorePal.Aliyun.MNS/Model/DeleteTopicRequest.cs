/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS DeleteTopic service.
    /// </summary>
    public partial class DeleteTopicRequest : MNSRequest
    {
        private string _topicName;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public DeleteTopicRequest() { }

        /// <summary>
        /// Instantiates DeleteTopicRequest with the parameterized properties
        /// </summary>
        /// <param name="topicName">The topic name to take action on.</param>
        public DeleteTopicRequest(string topicName)
        {
            _topicName = topicName;
        }

        /// <summary>
        /// Gets and sets the property topicName. 
        /// <para>
        /// The topic name to take action on.
        /// </para>
        /// </summary>
        public string TopicName
        {
            get { return this._topicName; }
            set { this._topicName = value; }
        }

        // Check to see if topicName property is set
        internal bool IsSetTopicName()
        {
            return this._topicName != null;
        }

    }
}