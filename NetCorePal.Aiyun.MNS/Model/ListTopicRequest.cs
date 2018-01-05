/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS ListTopic service.
    /// </summary>
    public partial class ListTopicRequest : MNSRequest
    {
        private string _marker;
        private uint? _maxReturns;
        private string _topicNamePrefix;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ListTopicRequest() { }

        /// <summary>
        /// Instantiates ListQueueRequest with single parameterized propertie
        /// </summary>
        public ListTopicRequest(string topicNamePrefix)
        {
            _topicNamePrefix = topicNamePrefix;
        }

        /// <summary>
        /// Instantiates ListTopicRequest with all parameterized properties
        /// </summary>
        public ListTopicRequest(string topicNamePrefix, string marker, uint maxReturns)
        {
            _topicNamePrefix = topicNamePrefix;
            _marker = marker;
            _maxReturns = maxReturns;
        }

        /// <summary>
        /// Gets and sets the property Marker. 
        /// </summary>
        public string Marker
        {
            get { return this._marker; }
            set { this._marker = value; }
        }

        // Check to see if Marker property is set
        internal bool IsSetMarker()
        {
            return this._marker != null;
        }

        /// <summary>
        /// Gets and sets the property MaxReturns. 
        /// </summary>
        public uint MaxReturns
        {
            get { return this._maxReturns.GetValueOrDefault(MNSConstants.DEFAULT_MAX_RETURNS); }
            set { this._maxReturns = value; }
        }

        // Check to see if MaxReturns property is set
        internal bool IsSetMaxReturns()
        {
            return this._maxReturns.HasValue;
        }

        /// <summary>
        /// Gets and sets the property TopicNamePrefix. 
        /// </summary>
        public string TopicNamePrefix
        {
            get { return this._topicNamePrefix; }
            set { this._topicNamePrefix = value; }
        }

        // Check to see if TopicNamePrefix property is set
        internal bool IsSetTopicNamePrefix()
        {
            return this._topicNamePrefix != null;
        }

    }
}