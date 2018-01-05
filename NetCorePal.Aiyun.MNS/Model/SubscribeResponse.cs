/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS Subscribe service
    /// </summary>
    public partial class SubscribeResponse : WebServiceResponse
    {
        private string _subscriptionUrl;

        /// <summary>
        /// Gets and sets the property SubscriptionUrl. 
        /// </summary>
        public string SubscriptionUrl
        {
            get { return this._subscriptionUrl; }
            set { this._subscriptionUrl = value; }
        }

        // Check to see if SubscriptionUrl property is set
        internal bool IsSetSubscriptionUrl()
        {
            return this._subscriptionUrl != null;
        }
    }
}