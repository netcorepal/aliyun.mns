using Aliyun.MNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS topic
    /// </summary>
    public partial interface ITopic
    {
        #region  GetAttributes

        /// <summary>
        /// Gets topic attributes.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        GetTopicAttributesResponse GetAttributes();

        Task<GetTopicAttributesResponse> GetAttributesAsync();

        /// <summary>
        /// Gets topic attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetTopicAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS GetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        GetTopicAttributesResponse GetAttributes(GetTopicAttributesRequest request);

        Task<GetTopicAttributesResponse> GetAttributesAsync(GetTopicAttributesRequest request);


        #endregion

        #region  SetAttributes

        /// <summary>
        /// Sets topic attributes.
        /// </summary>
        /// 
        /// <param name="attributes">The topic attributes to be set.</param>
        /// 
        /// <returns>The response returned by the MNS SetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided does not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should be between MIN and MAX seconds/bytes.
        /// </exception>
        SetTopicAttributesResponse SetAttributes(TopicAttributes attributes);

        Task<SetTopicAttributesResponse> SetAttributesAsync(TopicAttributes attributes);

        /// <summary>
        /// Sets topic attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetTopicAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        SetTopicAttributesResponse SetAttributes(SetTopicAttributesRequest request);

        Task<SetTopicAttributesResponse> SetAttributesAsync(SetTopicAttributesRequest request);


        #endregion

        #region  Subscribe

        /// <summary>
        /// Subscribe to topic.
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="endpoint">The endpoint for receiving notify messages.</param>
        /// 
        /// <returns>The response returned by the MNS Subscribe service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameLengthError">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionAlreadyExist">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="EndpointInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        SubscribeResponse Subscribe(string subscriptionName, string endpoint);

        Task<SubscribeResponse> SubscribeAsync(string subscriptionName, string endpoint);

        /// <summary>
        /// Subscribe to topic.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Subscribe service.</param>
        /// 
        /// <returns>The response returned by the MNS Subscribe service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameLengthError">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionAlreadyExist">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="EndpointInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        SubscribeResponse Subscribe(SubscribeRequest renquest);

        Task<SubscribeResponse> SubscribeAsync(SubscribeRequest request);


        #endregion

        #region  Unsubscribe

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// 
        /// <returns>The response returned by the MNS Unsubscribe service.</returns>
        UnsubscribeResponse Unsubscribe(string subscriptionName);

        Task<UnsubscribeResponse> UnsubscribeAsync(string subscriptionName);

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Unsubscribe service.</param>
        /// 
        /// <returns>The response returned by the MNS Unsubscribe service.</returns>
        UnsubscribeResponse Unsubscribe(UnsubscribeRequest renquest);

        Task<UnsubscribeResponse> UnsubscribeAsync(UnsubscribeRequest request);


        #endregion

        #region  GetSubscriptionAttribute

        /// <summary>
        /// GetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// 
        /// <returns>The response returned by the MNS GetSubscriptionAttribute service.</returns>
        /// <exception cref="SubscriptionNotExist">
        /// The subscription name you provided is not exist.
        /// </exception>
        GetSubscriptionAttributeResponse GetSubscriptionAttribute(string subscriptionName);

        Task<GetSubscriptionAttributeResponse> GetSubscriptionAttributeAsync(string subscriptionName);

        /// <summary>
        /// GetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetSubscriptionAttribute service.</param>
        /// 
        /// <returns>The response returned by the MNS GetSubscriptionAttribute service.</returns>
        GetSubscriptionAttributeResponse GetSubscriptionAttribute(GetSubscriptionAttributeRequest request);

        Task<GetSubscriptionAttributeResponse> GetSubscriptionAttributeAsync(GetSubscriptionAttributeRequest request);


        #endregion

        #region  SetSubscriptionAttribute

        /// <summary>
        /// SetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="subscriptionName">The SubscriptionAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS SetSubscriptionAttribute service.</returns>
        /// <exception cref="SubscriptionNotExist">
        /// The subscription name you provided is not exist.
        /// </exception>
        SetSubscriptionAttributeResponse SetSubscriptionAttribute(string subscriptionName, SubscriptionAttributes attributes);

        Task<SetSubscriptionAttributeResponse> SetSubscriptionAttributeAsync(string subscriptionName, SubscriptionAttributes attributes);

        /// <summary>
        /// SetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetSubscriptionAttribute service.</param>
        /// 
        /// <returns>The response returned by the MNS SetSubscriptionAttribute service.</returns>
        SetSubscriptionAttributeResponse SetSubscriptionAttribute(SetSubscriptionAttributeRequest request);

        Task<SetSubscriptionAttributeResponse> SetSubscriptionAttributeAsync(SetSubscriptionAttributeRequest request);


        #endregion

        #region  ListSubscription

        /// <summary>
        /// Returns a list of subscriptions with specified prefix.
        /// </summary>
        /// <param name="subscriptionNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix);

        Task<ListSubscriptionResponse> ListSubscriptionAsync(string subscriptionNamePrefix);

        /// <summary>
        /// Returns a list of subscriptions with specified prefix.
        /// </summary>
        /// <param name="subscriptionNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix, string marker, uint maxReturns);

        Task<ListSubscriptionResponse> ListSubscriptionAsync(string subscriptionNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your subscriptions with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListSubscription service.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(ListSubscriptionRequest request);
 
        Task<ListSubscriptionResponse> ListSubscriptionAsync(ListSubscriptionRequest request);


        #endregion

        #region  PublishMessage

        /// <summary>
        /// Delivers a message to the specified topic.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// 
        /// <returns>The response returned by the MNS PublishMessage service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        PublishMessageResponse PublishMessage(string messageBody);

        Task<PublishMessageResponse> PublishMessageAsync(string messageBody);

        /// <summary>
        /// Publish a message to this topic.
        /// </summary>
        /// <param name="request">The request object to be sent to MNS PublishMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS PublishMessage service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        PublishMessageResponse PublishMessage(PublishMessageRequest request);

        Task<PublishMessageResponse> PublishMessageAsync(PublishMessageRequest request);

        

        #endregion

        #region
        /// <summary>
        /// Generate Queue Endpoint, for subscription with a queue endpoint
        /// </summary>
        /// 
        /// <param name="queueName">The queue to receive topic messages.</param>
        /// 
        /// <returns>The queue endpoint.</returns>
        string GenerateQueueEndpoint(string queueName);

        /// <summary>
        /// Generate Mail Endpoint, for subscription with a mail endpoint
        /// </summary>
        /// 
        /// <param name="mailAddress">The mailAddress to receive topic messages.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateMailEndpoint(string mailAddress);

        /// <summary>
        /// Generate anonymous Sms Endpoint, for subscription with a sms endpoint
        /// </summary>
        /// 
        /// <param name="phone">The phone to receive sms.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateSmsEndpoint(string phone);

        /// <summary>
        /// Generate anonymous Sms Endpoint, for subscription with a sms endpoint
        /// </summary>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateSmsEndpoint();

        /// <summary>
        /// Generate anonymous BatchSms Endpoint, for subscription with a BatchSms endpoint
        /// </summary>
        /// 
        /// <param name="mailAddress">The mailAddress to receive topic messages.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateBatchSmsEndpoint();
        #endregion
    }
}
