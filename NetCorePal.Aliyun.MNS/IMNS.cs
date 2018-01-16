/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;
using System.Threading.Tasks;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS.
    /// </summary>
    public partial interface IMNS : IDisposable
    {
        #region  CreateQueue

        /// <summary>
        /// Creates a new queue with specified queue name.
        /// </summary>
        /// 
        /// <param name="queueName">The name for the queue to be created.</param>
        /// 
        /// <returns>A native queue object used to manipulate the newly queue.</returns>
        Queue CreateQueue(string queueName);

        Task<Queue> CreateQueueAsync(string queueName);

        /// <summary>
        /// Creates a new queue with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateQueue service.</param>
        /// 
        /// <returns>A native queue object used to manipulate the newly queue.</returns>
        /// <exception cref="QueueAlreadyExistException">
        /// A queue already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing queue.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The queue attributes specified in the request object whose values differ from those of the existing queue.
        /// </exception>
        Queue CreateQueue(CreateQueueRequest request);

        Task<Queue> CreateQueueAsync(CreateQueueRequest request);

       
        #endregion

        #region GetNativeQueue

        /// <summary>
        /// Get a native queue object with the specified queueName.
        /// </summary>
        /// 
        /// <param name="queueName">The name of native queue object to be created</param>
        /// 
        /// <returns>A native queue object</returns>
        Queue GetNativeQueue(string queueName);

        #endregion

        #region  DeleteQueue

        /// <summary>
        /// Deletes the queue specified by the <b>queue name</b>.
        /// </summary>
        /// 
        /// <param name="queueName">The queue name to be deleted.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteQueue service.</returns>
        DeleteQueueResponse DeleteQueue(string queueName);

        Task<DeleteQueueResponse> DeleteQueueAsync(string queueName);

        /// <summary>
        /// Deletes the queue with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteQueue service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteQueue service.</returns>
        DeleteQueueResponse DeleteQueue(DeleteQueueRequest request);  
        Task<DeleteQueueResponse> DeleteQueueAsync(DeleteQueueRequest request);


        #endregion

        #region  ListQueue

        /// <summary>
        /// Returns a list of your queues with specified prefix.
        /// </summary>
        /// <param name="queueNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(string queueNamePrefix);

        Task<ListQueueResponse> ListQueueAsync(string queueNamePrefix);

        /// <summary>
        /// Returns a list of your queues with specified conditions.
        /// </summary>
        /// <param name="queueNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(string queueNamePrefix, string marker, uint maxReturns);

        Task<ListQueueResponse> ListQueueAsync(string queueNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your queues with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListQueue service.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(ListQueueRequest request);

        Task<ListQueueResponse> ListQueueAsync(ListQueueRequest request);

       
        #endregion

        #region CreateTopic
        /// <summary>
        /// Creates a new topic with specified topic name.
        /// </summary>
        /// 
        /// <param name="topicName">The name for the topic to be created.</param>
        /// 
        /// <returns>A native topic object used to manipulate the newly queue.</returns>
        /// <exception cref="TopicAlreadyExistException">
        /// A topic already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing topic.
        /// </exception>
        /// <exception cref="TopicNameLengthErrorException">
        /// the length of topic name is not suitable
        /// </exception>
        /// <exception cref="TopicNameInvalidException">
        /// the topic name contains invalid characters.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// the argument provided is invalid
        /// </exception>
        Topic CreateTopic(string topicName);

        Task<Topic> CreateTopicAsync(string topicName);


        /// <summary>
        /// Creates a new topic with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateTopic service.</param>
        /// 
        /// <returns>A native topic object used to manipulate the newly topic.</returns>
        /// <exception cref="TopicAlreadyExistException">
        /// A topic already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing topic.
        /// </exception>
        /// <exception cref="TopicNameLengthErrorException">
        /// the length of topic name is not suitable
        /// </exception>
        /// <exception cref="TopicNameInvalidException">
        /// the topic name contains invalid characters.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// the argument provided is invalid
        /// </exception>
        Topic CreateTopic(CreateTopicRequest request);

        Task<Topic> CreateTopicAsync(CreateTopicRequest request);

        #endregion

        #region GetNativeTopic

        /// <summary>
        /// Get a native topic object with the specified topicName.
        /// </summary>
        /// 
        /// <param name="topicName">The name of native topic object to be created</param>
        /// 
        /// <returns>A native topic object</returns>
        Topic GetNativeTopic(string topicName);

        #endregion

        #region  DeleteTopic

        /// <summary>
        /// Deletes the topic specified by the <b>topic name</b>.
        /// </summary>
        /// 
        /// <param name="topicName">The topic name to be deleted.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteTopic service.</returns>
        DeleteTopicResponse DeleteTopic(string queueName);

        Task<DeleteTopicResponse> DeleteTopicAsync(string queueName);

        /// <summary>
        /// Deletes the topic with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteTopic service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteTopic service.</returns>
        DeleteTopicResponse DeleteTopic(DeleteTopicRequest request);

        Task<DeleteTopicResponse> DeleteTopicAsync(DeleteTopicRequest request);

        #endregion

        #region  ListTopic

        /// <summary>
        /// Returns a list of your topics with specified prefix.
        /// </summary>
        /// <param name="topicNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(string topicNamePrefix);

        Task<ListTopicResponse> ListTopicAsync(string topicNamePrefix);

        /// <summary>
        /// Returns a list of your topics with specified conditions.
        /// </summary>
        /// <param name="topicNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(string topicNamePrefix, string marker, uint maxReturns);

        Task<ListTopicResponse> ListTopicAsync(string topicNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your topics with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListTopic service.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(ListTopicRequest request);

        Task<ListTopicResponse> ListTopicAsync(ListTopicRequest request);

        #endregion

        #region SetAccountAttributes

        /// <summary>
        /// set account attributes
        /// </summary>
        /// <param name="AccountAttributes">account attributes</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        SetAccountAttributesResponse SetAccountAttributes(AccountAttributes attributes);

        Task<SetAccountAttributesResponse> SetAccountAttributesAsync(AccountAttributes attributes);

        /// <summary>
        /// set account attributes
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetAccountAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        SetAccountAttributesResponse SetAccountAttributes(SetAccountAttributesRequest request);

        Task<SetAccountAttributesResponse> SetAccountAttributesAsync(SetAccountAttributesRequest request);
       

        #endregion

        #region GetAccountAttributes

        /// <summary>
        /// get account attributes
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetAccountAttributes service.</returns>
        GetAccountAttributesResponse GetAccountAttributes();

        Task<GetAccountAttributesResponse> GetAccountAttributesAsync();

        /// <summary>
        /// get account attributes
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetAccountAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        GetAccountAttributesResponse GetAccountAttributes(GetAccountAttributesRequest request);

        Task<GetAccountAttributesResponse> GetAccountAttributesAsync(GetAccountAttributesRequest request);

       
        #endregion
    }
}
