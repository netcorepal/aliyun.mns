/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS GetTopicAttributes service.
    /// </summary>
    public partial class GetSubscriptionAttributeRequest : SimpleMNSRequest
    {
        private string _subscriptionName;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public GetSubscriptionAttributeRequest() { }

        /// <summary>
        /// Instantiates GetSubscriptionAttributeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The subscriptionName.</param>
        public GetSubscriptionAttributeRequest(string subscriptionName)
        {
            _subscriptionName = subscriptionName;
        }

        /// <summary>
        /// Gets and sets the property SubscriptionName. 
        /// <para>
        /// The SubscriptionName.
        /// </para>
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
    }
}