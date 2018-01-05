/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System.Collections.Generic;
using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS ListTopic service
    /// </summary>
    public partial class ListTopicResponse : WebServiceResponse
    {
        private List<string> _topicUrls = new List<string>();
        private string _nextMarker;

        /// <summary>
        /// Gets and sets the property TopicUrls. 
        /// </summary>
        public List<string> TopicUrls
        {
            get { return this._topicUrls; }
            set { this._topicUrls = value; }
        }

        // Check to see if TopicUrls property is set
        public bool IsSetTopicUrls()
        {
            return this._topicUrls != null && this._topicUrls.Count > 0;
        }

        /// <summary>
        /// Gets and sets the property NextMarker. 
        /// </summary>
        public string NextMarker
        {
            get { return this._nextMarker; }
            set { this._nextMarker = value; }
        }

        // Check to see if NextMarker property is set
        public bool IsSetNextMarker()
        {
            return this._nextMarker != null;
        }
    }
}