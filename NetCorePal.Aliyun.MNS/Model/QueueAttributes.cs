/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for a set of queue attributes.
    /// </summary>
    public partial class QueueAttributes
    {
        private string _queueName;
        
        private DateTime? _createTime;
        private DateTime? _lastModifyTime;

        private uint? _delaySeconds;
        private uint? _visibilityTimeout;
        private uint? _maximumMessageSize;
        private uint? _messageRetentionPeriod;
        private uint? _pollingWaitSeconds;
        
        private uint? _inactiveMessages;
        private uint? _activeMessages;
        private uint? _delayMessages;

        private bool? _loggingEnabled;

        /// <summary>
        /// Gets and sets the property QueueName. 
        /// </summary>
        public string QueueName
        {
            get { return this._queueName; }
            set { this._queueName = value; }
        }

        // Check to see if QueueName property is set
        internal bool IsSetQueueName()
        {
            return this._queueName != null;
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
        /// Gets and sets the property VisibilityTimeout. 
        /// </summary>
        public uint VisibilityTimeout
        {
            get { return this._visibilityTimeout.GetValueOrDefault(MNSConstants.DEFAULT_VISIBILITY_TIMEOUT); }
            set { this._visibilityTimeout = value; }
        }

        // Check to see if VisibilityTimeout property is set
        internal bool IsSetVisibilityTimeout()
        {
            return this._visibilityTimeout != null;
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
        /// Gets and sets the property DelaySeconds. 
        /// </summary>
        public uint DelaySeconds
        {
            get { return this._delaySeconds.GetValueOrDefault(MNSConstants.DEFAULT_DELAY_SECONDS); }
            set { this._delaySeconds = value; }
        }

        // Check to see if DelaySeconds property is set
        internal bool IsSetDelaySeconds()
        {
            return this._delaySeconds != null;
        }

        /// <summary>
        /// Gets and sets the property PollingWaitSeconds. 
        /// </summary>
        public uint PollingWaitSeconds
        {
            get { return this._pollingWaitSeconds.GetValueOrDefault(MNSConstants.DEFAULT_POLLING_WAIT_SECONDS); }
            set { this._pollingWaitSeconds = value; }
        }

        // Check to see if PollingWaitSeconds property is set
        internal bool IsSetPollingWaitSeconds()
        {
            return this._pollingWaitSeconds != null;
        }

        /// <summary>
        /// Gets and sets the property InactiveMessages. 
        /// </summary>
        public uint InactiveMessages
        {
            get { return this._inactiveMessages.GetValueOrDefault(); }
            set { this._inactiveMessages = value; }
        }

        // Check to see if InactiveMessages property is set
        internal bool IsSetInactiveMessages()
        {
            return this._inactiveMessages != null;
        }

        /// <summary>
        /// Gets and sets the property ActiveMessages. 
        /// </summary>
        public uint ActiveMessages
        {
            get { return this._activeMessages.GetValueOrDefault(); }
            set { this._activeMessages = value; }
        }

        // Check to see if ActiveMessages property is set
        internal bool IsSetActiveMessages()
        {
            return this._activeMessages != null;
        }

        /// <summary>
        /// Gets and sets the property DelayMessages. 
        /// </summary>
        public uint DelayMessages
        {
            get { return this._delayMessages.GetValueOrDefault(); }
            set { this._delayMessages = value; }
        }

        // Check to see if DelayMessages property is set
        internal bool IsSetDelayMessages()
        {
            return this._delayMessages != null;
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
