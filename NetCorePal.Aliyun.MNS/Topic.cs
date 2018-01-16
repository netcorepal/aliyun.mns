/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCorePal.Aliyun.MNS.Util;

namespace Aliyun.MNS
{
    /// <summary>
    /// Implementation for accessing MNS topic
    /// </summary>
    public partial class Topic : ITopic
    {
        #region Properties

        private string _topicName;
        private readonly AliyunServiceClient _serviceClient;
        private string _accountId = "";
        private string _region = "";

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates Topic with the parameterized properties
        /// </summary>
        public Topic(string topicName, AliyunServiceClient serviceClient)
        {
            _topicName = topicName;
            _serviceClient = serviceClient;

            Uri endpointUri = serviceClient.Config.RegionEndpoint;
            if (endpointUri != null)
            {
                string[] hostPieces = endpointUri.Host.Split('.');
                _accountId = hostPieces[0];
                _region = hostPieces[2].Split(new[] { "-internal" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets and sets the property TopicName
        /// </summary>
        public string TopicName
        {
            get { return this._topicName; }
            set { this._topicName = value; }
        }

        /// <summary>
        /// Check to see if TopicName property is set
        /// </summary>
        public bool IsSetTopicName()
        {
            return this._topicName != null;
        }

        #endregion

        #region  GetAttributes

        /// <inheritdoc/>
        public GetTopicAttributesResponse GetAttributes()
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAttributesAsync().Result;
            });
           
        }

        public async Task<GetTopicAttributesResponse> GetAttributesAsync()
        {
            var request = new GetTopicAttributesRequest();
            return await GetAttributesAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public GetTopicAttributesResponse GetAttributes(GetTopicAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAttributesAsync(request).Result;
            });
            
        }

        public async Task<GetTopicAttributesResponse> GetAttributesAsync(GetTopicAttributesRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetTopicAttributesRequestMarshaller();
            var unmarshaller = GetTopicAttributesResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<GetTopicAttributesRequest, GetTopicAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }


        #endregion

        #region  SetAttributes

        /// <inheritdoc/>
        public SetTopicAttributesResponse SetAttributes(TopicAttributes attributes)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAttributesAsync(attributes).Result;
            });
          
        }

        public async Task<SetTopicAttributesResponse> SetAttributesAsync(TopicAttributes attributes)
        {
            var request = new SetTopicAttributesRequest { Attributes = attributes };
            return await SetAttributesAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public SetTopicAttributesResponse SetAttributes(SetTopicAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAttributesAsync(request).Result;
            });
            
        }

        public async Task<SetTopicAttributesResponse> SetAttributesAsync(SetTopicAttributesRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetTopicAttributesRequestMarshaller();
            var unmarshaller = SetTopicAttributesResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<SetTopicAttributesRequest, SetTopicAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

       
        #endregion

        #region  Subscribe

        /// <inheritdoc/>
        public SubscribeResponse Subscribe(string subscriptionName, string endpoint)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SubscribeAsync(subscriptionName, endpoint).Result;
            });
            
        }

        public async Task<SubscribeResponse> SubscribeAsync(string subscriptionName, string endpoint)
        {
            return await SubscribeAsync(new SubscribeRequest(subscriptionName, endpoint)).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public SubscribeResponse Subscribe(SubscribeRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SubscribeAsync(request).Result;
            });
            
        }

        public async Task<SubscribeResponse> SubscribeAsync(SubscribeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SubscribeRequestMarshaller();
            var unmarshaller = SubscribeResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<SubscribeRequest, SubscribeResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  Unsubscribe

        /// <inheritdoc/>
        public UnsubscribeResponse Unsubscribe(string subscriptionName)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return UnsubscribeAsync(subscriptionName).Result;
            });
           
        }

        public async Task<UnsubscribeResponse> UnsubscribeAsync(string subscriptionName)
        {
            return await UnsubscribeAsync(new UnsubscribeRequest(subscriptionName)).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public UnsubscribeResponse Unsubscribe(UnsubscribeRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return UnsubscribeAsync(request).Result;
            });
           
        }

        public async Task<UnsubscribeResponse> UnsubscribeAsync(UnsubscribeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new UnsubscribeRequestMarshaller();
            var unmarshaller = UnsubscribeResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<UnsubscribeRequest, UnsubscribeResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  GetSubscriptionAttribute

        /// <inheritdoc/>
        public GetSubscriptionAttributeResponse GetSubscriptionAttribute(string subscriptionName)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetSubscriptionAttributeAsync(subscriptionName).Result;
            });
           
        }

        public async Task<GetSubscriptionAttributeResponse> GetSubscriptionAttributeAsync(string subscriptionName)
        {
            return await GetSubscriptionAttributeAsync(new GetSubscriptionAttributeRequest(subscriptionName)).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public GetSubscriptionAttributeResponse GetSubscriptionAttribute(GetSubscriptionAttributeRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetSubscriptionAttributeAsync(request).Result;
            });
            
        }

        public async Task<GetSubscriptionAttributeResponse> GetSubscriptionAttributeAsync(GetSubscriptionAttributeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = GetSubscriptionAttributeResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<GetSubscriptionAttributeRequest, GetSubscriptionAttributeResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }
       
        #endregion

        #region  SetSubscriptionAttribute

        /// <inheritdoc/>
        public SetSubscriptionAttributeResponse SetSubscriptionAttribute(string subscriptionName, SubscriptionAttributes attributes)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetSubscriptionAttributeAsync(subscriptionName, attributes).Result;
            });
          
        }

        public async Task<SetSubscriptionAttributeResponse> SetSubscriptionAttributeAsync(string subscriptionName, SubscriptionAttributes attributes)
        {
            return await SetSubscriptionAttributeAsync(new SetSubscriptionAttributeRequest(subscriptionName, attributes)).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public SetSubscriptionAttributeResponse SetSubscriptionAttribute(SetSubscriptionAttributeRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetSubscriptionAttributeAsync(request).Result;
            });
            
        }

       
        public async Task<SetSubscriptionAttributeResponse> SetSubscriptionAttributeAsync(SetSubscriptionAttributeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = SetSubscriptionAttributeResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<SetSubscriptionAttributeRequest, SetSubscriptionAttributeResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  ListSubscription

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListSubscriptionAsync(subscriptionNamePrefix).Result;
            });
            
        }

        public async Task<ListSubscriptionResponse> ListSubscriptionAsync(string subscriptionNamePrefix)
        {
            var request = new ListSubscriptionRequest()
            {
                SubscriptionNamePrefix = subscriptionNamePrefix,
                TopicName = this.TopicName
            };
            return await ListSubscriptionAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix, string marker, uint maxReturns)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListSubscriptionAsync(subscriptionNamePrefix, marker, maxReturns).Result;
            });
            
        }

        public async Task<ListSubscriptionResponse> ListSubscriptionAsync(string subscriptionNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListSubscriptionRequest()
            {
                TopicName = this.TopicName,
                SubscriptionNamePrefix = subscriptionNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return await ListSubscriptionAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(ListSubscriptionRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListSubscriptionAsync(request).Result;
            });
           
        }

        public async Task<ListSubscriptionResponse> ListSubscriptionAsync(ListSubscriptionRequest request)
        {
            request.TopicName = this.TopicName;
            var marshaller = new ListSubscriptionRequestMarshaller();
            var unmarshaller = ListSubscriptionResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<ListSubscriptionRequest, ListSubscriptionResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        
        #endregion

        #region  PublishMessage

        /// <inheritdoc/>
        public PublishMessageResponse PublishMessage(string messageBody)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return PublishMessageAsync(messageBody).Result;
            });
           
        }

        public async Task<PublishMessageResponse> PublishMessageAsync(string messageBody)
        {
            var request = new PublishMessageRequest { MessageBody = messageBody };
            return await PublishMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public PublishMessageResponse PublishMessage(PublishMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return PublishMessageAsync(request).Result;
            });
           
        }

        public async Task<PublishMessageResponse> PublishMessageAsync(PublishMessageRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new PublishMessageRequestMarshaller();
            var unmarshaller = PublishMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<PublishMessageRequest, PublishMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        
        #endregion

        #region
        /// <inheritdoc/>
        public string GenerateQueueEndpoint(string queueName)
        { 
            return "acs:mns:" + this._region + ":" + this._accountId + ":queues/" + queueName;
        }

        /// <inheritdoc/>
        public string GenerateMailEndpoint(string mailAddress)
        { 
            return "mail:directmail:" + mailAddress;
        }

        /// <inheritdoc/>
        public string GenerateSmsEndpoint(string phone)
        {
            return "sms:directsms:" + phone;
        }

        /// <inheritdoc/>
        public string GenerateSmsEndpoint()
        {
            return "sms:directsms:anonymous";
        }

        /// <inheritdoc/>
        public string GenerateBatchSmsEndpoint()
        {
            return "sms:directsms:anonymous";
        }
        #endregion
    }
}
