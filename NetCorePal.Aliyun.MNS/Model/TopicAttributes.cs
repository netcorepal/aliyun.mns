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
    public partial class TopicAttributes
    {
        private string _topicName;
        private uint? _messageCount;

        private DateTime? _createTime;
        private DateTime? _lastModifyTime;

        private uint? _maximumMessageSize;
        private uint? _messageRetentionPeriod;

        private bool? _loggingEnabled;

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
        /// Gets and sets the property MessageCount. 
        /// </summary>
        public uint MessageCount
        {
            get { return this._messageCount.GetValueOrDefault(); }
            set { this._messageCount = value; }
        }

        // Check to see if TopicName property is set
        internal bool IsSetMessageCount()
        {
            return this._messageCount != null;
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

        /// <summary>
        /// Gets and sets the property MaximumMessageSize. 
        /// </summary>
        public uint MaximumMessageSize
        {
            get { return this._maximumMessageSize.GetValueOrDefault(MNSConstants.DEFAULT_MAXIMUM_MESSAGE_SIZE); }
            set { this._maximumMessageSize = value; }
        }

        // Check to see if MaximumMessageSize property is set
        internal bool IsSetMaximumMessageSize()
        {
            return this._maximumMessageSize != null;
        }

        /// <summary>
        /// Gets and sets the property MessageRetentionPeriod. 
        /// </summary>
        public uint MessageRetentionPeriod
        {
            get { return this._messageRetentionPeriod.GetValueOrDefault(MNSConstants.DEFAULT_MESSAGE_RETENTION_PERIOD); }
            set { this._messageRetentionPeriod = value; }
        }

        // Check to see if MessageRetentionPeriod property is set
        internal bool IsSetMessageRetentionPeriod()
        {
            return this._messageRetentionPeriod != null;
        }

        /// <summary>
        /// Gets and sets the property LoggingEnabled. 
        /// </summary>
        public bool LoggingEnabled
        {
            get { return this._loggingEnabled.GetValueOrDefault(); }
            set { this._loggingEnabled = value; }
        }

        // Check to see if LoggingEnabled property is set
        internal bool IsSetLoggingEnabled()
        {
            return this._loggingEnabled != null;
        }
    }
}
