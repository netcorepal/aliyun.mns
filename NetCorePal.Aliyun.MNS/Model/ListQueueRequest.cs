/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS ListQueue service.
    /// </summary>
    public partial class ListQueueRequest : MNSRequest
    {
        private string _marker;
        private uint? _maxReturns;
        private string _queueNamePrefix;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ListQueueRequest() { }

        /// <summary>
        /// Instantiates ListQueueRequest with single parameterized propertie
        /// </summary>
        public ListQueueRequest(string queueNamePrefix)
        {
            _queueNamePrefix = queueNamePrefix;
        }

        /// <summary>
        /// Instantiates ListQueueRequest with all parameterized properties
        /// </summary>
        public ListQueueRequest(string queueNamePrefix, string marker, uint maxReturns)
        {
            _queueNamePrefix = queueNamePrefix;
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
        /// Gets and sets the property QueueNamePrefix. 
        /// </summary>
        public string QueueNamePrefix
        {
            get { return this._queueNamePrefix; }
            set { this._queueNamePrefix = value; }
        }

        // Check to see if QueueNamePrefix property is set
        internal bool IsSetQueueNamePrefix()
        {
            return this._queueNamePrefix != null;
        }

    }
}