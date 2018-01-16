/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS CreateTopic service
    /// </summary>
    public partial class CreateTopicResponse : WebServiceResponse
    {
        private string _topicUrl;

        /// <summary>
        /// Gets and sets the property TopicUrl. 
        /// </summary>
        public string TopicUrl
        {
            get { return this._topicUrl; }
            set { this._topicUrl = value; }
        }

        // Check to see if TopicUrl property is set
        internal bool IsSetTopicUrl()
        {
            return this._topicUrl != null;
        }
    }
}