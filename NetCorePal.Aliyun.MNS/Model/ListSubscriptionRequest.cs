/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS ListSubscription service.
    /// </summary>
    public partial class ListSubscriptionRequest : SimpleMNSRequest
    {
        private string _marker;
        private uint? _maxReturns;
        private string _subscriptionNamePrefix;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ListSubscriptionRequest() { }

        /// <summary>
        /// Instantiates ListSubscriptionRequest with single parameterized propertie
        /// </summary>
        public ListSubscriptionRequest(string subscriptionNamePrefix)
        {
            _subscriptionNamePrefix = subscriptionNamePrefix;
        }

        /// <summary>
        /// Instantiates ListSubscriptionRequest with all parameterized properties
        /// </summary>
        public ListSubscriptionRequest(string subscriptionNamePrefix, string marker, uint maxReturns)
        {
            _subscriptionNamePrefix = subscriptionNamePrefix;
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
        /// Gets and sets the property SubscriptionNamePrefix. 
        /// </summary>
        public string SubscriptionNamePrefix
        {
            get { return this._subscriptionNamePrefix; }
            set { this._subscriptionNamePrefix = value; }
        }

        // Check to see if SubscriptionNamePrefix property is set
        internal bool IsSetSubscriptionNamePrefix()
        {
            return this._subscriptionNamePrefix != null;
        }

    }
}