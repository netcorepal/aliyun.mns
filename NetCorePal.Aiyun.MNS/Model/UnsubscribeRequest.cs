/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS Unsubscribe service.
    /// </summary>
    public partial class UnsubscribeRequest : SimpleMNSRequest
    {
        private string _subscriptionName;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public UnsubscribeRequest() { }

        /// <summary>
        /// Instantiates UnsubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The subscriptionName to take action on.</param>
        public UnsubscribeRequest(string subscriptionName)
        {
            _subscriptionName = subscriptionName;
        }

        /// <summary>
        /// Gets and sets the property subscriptionName. 
        /// <para>
        /// The subscription name to take action on.
        /// </para>
        /// </summary>
        public string SubscriptionName
        {
            get { return this._subscriptionName; }
            set { this._subscriptionName = value; }
        }

        // Check to see if subscriptionName property is set
        internal bool IsSetSubscriptionName()
        {
            return this._subscriptionName != null;
        }
    }
}