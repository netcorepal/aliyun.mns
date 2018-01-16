/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS Subscribe service.
    /// </summary>
    public partial class SubscribeRequest : SimpleMNSRequest
    {
        private string _subscriptionName;
        private string _endpoint;
        private string _filterTag;
        private SubscriptionAttributes.NotifyStrategy? _strategy;
        private SubscriptionAttributes.NotifyContentFormat? _contentFormat;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SubscribeRequest() { }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        public SubscribeRequest(string subscriptionName, string endpoint)
            : this(subscriptionName, endpoint, SubscriptionAttributes.NotifyStrategy.BACKOFF_RETRY)
        {   
        }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        /// <param name="filterTag">The subscribe filterTag.</param>
        public SubscribeRequest(string subscriptionName, string endpoint, string filterTag)
            : this(subscriptionName, endpoint, filterTag, SubscriptionAttributes.NotifyStrategy.BACKOFF_RETRY)
        {
        }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        /// <param name="strategy">The NotifyStrategy for the subscription.</param>
        public SubscribeRequest(string subscriptionName, 
            string endpoint, SubscriptionAttributes.NotifyStrategy strategy)
             : this(subscriptionName, endpoint, strategy, SubscriptionAttributes.NotifyContentFormat.XML)
        {
        }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        /// <param name="strategy">The NotifyStrategy for the subscription.</param>
        /// <param name="filterTag">The subscribe filterTag.</param>
        public SubscribeRequest(string subscriptionName,
            string endpoint, string filterTag, SubscriptionAttributes.NotifyStrategy strategy)
             : this(subscriptionName, endpoint, strategy, SubscriptionAttributes.NotifyContentFormat.XML)
        {
        }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        /// <param name="strategy">The NotifyStrategy for the subscription.</param>
        /// <param name="contentFormat">The NotifyContentFormat for the subscription.</param>
        public SubscribeRequest(string subscriptionName,
            string endpoint, 
            SubscriptionAttributes.NotifyStrategy strategy, 
            SubscriptionAttributes.NotifyContentFormat contentFormat)
            : this(subscriptionName, endpoint, null, strategy, SubscriptionAttributes.NotifyContentFormat.XML)
        {
        }

        /// <summary>
        /// Instantiates SubscribeRequest with the parameterized properties
        /// </summary>
        /// <param name="subscriptionName">The name for the subscription to be created.</param>
        /// <param name="endpoint">The subscribe endpoint.</param>
        /// <param name="filterTag">The subscribe filterTag.</param>
        /// <param name="strategy">The NotifyStrategy for the subscription.</param>
        /// <param name="contentFormat">The NotifyContentFormat for the subscription.</param>
        public SubscribeRequest(string subscriptionName,
            string endpoint, string filterTag,
            SubscriptionAttributes.NotifyStrategy strategy,
            SubscriptionAttributes.NotifyContentFormat contentFormat)
        {
            _subscriptionName = subscriptionName;
            _endpoint = endpoint;
            _filterTag = filterTag;
            _strategy = strategy;
            _contentFormat = contentFormat;
        }

        /// <summary>
        /// Gets and sets the property Strategy. 
        /// </summary>
        public SubscriptionAttributes.NotifyStrategy Strategy
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
        /// Gets and sets the property ContentFormat. 
        /// </summary>
        public SubscriptionAttributes.NotifyContentFormat ContentFormat
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
        /// Gets and sets the property FilterTag. 
        /// </summary>
        public string FilterTag
        {
            get { return this._filterTag; }
            set { this._filterTag = value; }
        }

        // Check to see if FilterTag property is set
        internal bool IsSetFilterTag()
        {
            return this._filterTag != null;
        }
    }
}