/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for a set of topic attributes.
    /// </summary>
    public partial class SubscriptionAttributes
    {
        public enum NotifyStrategy
        {
            BACKOFF_RETRY,
            EXPONENTIAL_DECAY_RETRY
        }

        public enum NotifyContentFormat
        {
            XML,
            SIMPLIFIED,
            JSON
        }

        private string _endpoint;

        private string _subscriptionName;
        private string _topicName;
        private string _topicOwner;
        private NotifyStrategy? _strategy;
        private NotifyContentFormat? _contentFormat;
        private DateTime? _createTime;
        private DateTime? _lastModifyTime;

        /// <summary>
        /// Gets and sets the property Strategy. 
        /// </summary>
        public NotifyStrategy Strategy
        {
            get { return this._strategy.GetValueOrDefault(); }
            set { this._strategy = value; }
        }

        // Check to see if Strategy property is set
        internal bool IsSetStrategy()
        {
            return this._strategy != null;
        }

        /// <summary>
        /// Gets and sets the property Strategy. 
        /// </summary>
        public NotifyContentFormat ContentFormat
        {
            get { return this._contentFormat.GetValueOrDefault(); }
            set { this._contentFormat = value; }
        }

        // Check to see if Strategy property is set
        internal bool IsSetContentFormat()
        {
            return this._contentFormat != null;
        }

        /// <summary>
        /// Gets and sets the property EndPoint. 
        /// </summary>
        public string EndPoint
        {
            get { return this._endpoint; }
            set { this._endpoint = value; }
        }

        // Check to see if EndPoint property is set
        internal bool IsSetEndPoint()
        {
            return this._endpoint != null;
        }

        /// <summary>
        /// Gets and sets the property SubscriptionName. 
        /// </summary>
        public string SubscriptionName
        {
            get { return this._subscriptionName; }
            set { this._subscriptionName = value; }
        }

        // Check to see if SubscriptionName property is set
        internal bool IsSetSubscriptionName()
        {
            return this._subscriptionName != null;
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

        /// <summary>
        /// Gets and sets the property TopicOwner. 
        /// </summary>
        public string TopicOwner
        {
            get { return this._topicOwner; }
            set { this._topicOwner = value; }
        }

        // Check to see if TopicOwner property is set
        internal bool IsSetTopicOwner()
        {
            return this._topicOwner != null;
        }

        /// <summary>
        /// Gets and sets the property CreateTime. 
        /// </summary>
        public DateTime CreateTime
        {
            get { return this._createTime.GetValueOrDefault(); }
            set { this._createTime = value; }
        }

        // Check to see if CreateTime property is set
        internal bool IsSetCreateTime()
        {
            return this._createTime != null;
        }

        /// <summary>
        /// Gets and sets the property LastModifyTime. 
        /// </summary>
        public DateTime LastModifyTime
        {
            get { return this._lastModifyTime.GetValueOrDefault(); }
            set { this._lastModifyTime = value; }
        }

        // Check to see if LastModifyTime property is set
        internal bool IsSetLastModifyTime()
        {
            return this._lastModifyTime != null;
        }
    }
}
