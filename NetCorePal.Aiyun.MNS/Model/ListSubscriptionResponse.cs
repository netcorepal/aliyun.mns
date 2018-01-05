/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System.Collections.Generic;
using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS ListSubscription service
    /// </summary>
    public partial class ListSubscriptionResponse : WebServiceResponse
    {
        private List<string> _subscriptionUrls = new List<string>();
        private string _nextMarker;

        /// <summary>
        /// Gets and sets the property SubscriptionUrls. 
        /// </summary>
        public List<string> SubscriptionUrls
        {
            get { return this._subscriptionUrls; }
            set { this._subscriptionUrls = value; }
        }

        // Check to see if SubscriptionUrls property is set
        public bool IsSetSubscriptionUrls()
        {
            return this._subscriptionUrls != null && this._subscriptionUrls.Count > 0;
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