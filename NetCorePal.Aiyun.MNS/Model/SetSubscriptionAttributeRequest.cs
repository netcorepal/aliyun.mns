/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS SetSubscriptionAttribute service.
    /// </summary>
    public partial class SetSubscriptionAttributeRequest : SimpleMNSRequest
    {
        private string _subscriptionName;
        private SubscriptionAttributes _attributes = new SubscriptionAttributes();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SetSubscriptionAttributeRequest() { }

        /// <summary>
        /// Instantiates SetSubscriptionAttributeRequest with the parameterized properties
        /// </summary>
        /// <param name="attributes">The subscription attributes to set.</param>
        public SetSubscriptionAttributeRequest(string subscriptionName, SubscriptionAttributes attributes)
        {
            _subscriptionName = subscriptionName;
            _attributes = attributes;
        }

        /// <summary>
        /// Gets and sets the property Attributes.
        /// </summary>
        public SubscriptionAttributes Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
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
