/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS queue
    /// </summary>
    public partial interface IQueue
    {
        #region  GetAttributes

        /// <summary>
        /// Gets queue attributes.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        GetQueueAttributesResponse GetAttributes();

        Task<GetQueueAttributesResponse> GetAttributesAsync();

        /// <summary>
        /// Gets queue attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetQueueAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS GetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        GetQueueAttributesResponse GetAttributes(GetQueueAttributesRequest request);

        Task<GetQueueAttributesResponse> GetAttributesAsync(GetQueueAttributesRequest request);


        #endregion

        #region  SetAttributes

        /// <summary>
        /// Sets queue attributes.
        /// </summary>
        /// 
        /// <param name="attributes">The queue attributes to be set.</param>
        /// 
        /// <returns>The response returned by the MNS SetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided does not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should be between MIN and MAX seconds/bytes.
        /// </exception>
        SetQueueAttributesResponse SetAttributes(QueueAttributes attributes);

        Task<SetQueueAttributesResponse> SetAttributesAsync(QueueAttributes attributes);

        /// <summary>
        /// Sets queue attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetQueueAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SetQueueAttributesResponse SetAttributes(SetQueueAttributesRequest request);

        Task<SetQueueAttributesResponse> SetAttributesAsync(SetQueueAttributesRequest request);

        
        #endregion

        #region  ChangeMessageVisibility

        /// <summary>
        /// Changes the visibility timeout of a specified message of the queue to a new value.
        /// </summary>
        /// 
        /// <param name="receiptHandle">The receipt handle associated with the message whose visibility timeout should be changed. </param>
        /// <param name="visibilityTimeout">The new value for the message's visibility timeout.</param>
        /// 
        /// <returns>The response returned by the MNS ChangeMessageVisibility service.</returns>
        ChangeMessageVisibilityResponse ChangeMessageVisibility(string receiptHandle, int visibilityTimeout);

        Task<ChangeMessageVisibilityResponse> ChangeMessageVisibilityAsync(string receiptHandle, int visibilityTimeout);

        /// <summary>
        /// Changes the visibility timeout of a specified message of the queue to a new value.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ChangeMessageVisibility service.</param>
        /// 
        /// <returns>The response returned by the MNS ChangeMessageVisibility service.</returns>
        ChangeMessageVisibilityResponse ChangeMessageVisibility(ChangeMessageVisibilityRequest request);

        Task<ChangeMessageVisibilityResponse> ChangeMessageVisibilityAsync(ChangeMessageVisibilityRequest request);

        #endregion
        
        #region  DeleteMessage

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="receiptHandle">The receipt handle associated with the message to delete.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between Low and High seconds/bytes.
        /// </exception>
        DeleteMessageResponse DeleteMessage(string receiptHandle);

        Task<DeleteMessageResponse> DeleteMessageAsync(string receiptHandle);

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="request">The request object to be sent to MNS DeleteMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between Low and High seconds/bytes.
        /// </exception>
        DeleteMessageResponse DeleteMessage(DeleteMessageRequest request);

        Task<DeleteMessageResponse> DeleteMessageAsync(DeleteMessageRequest request);

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="request">The request object to be sent to MNS BatchDeleteMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS BatchDeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between MIN and MAX seconds/bytes.
        /// </exception>
        /// <exception cref="BatchDeleteFailException">
        /// Some messages are not deleted.
        /// </exception>
        BatchDeleteMessageResponse BatchDeleteMessage(BatchDeleteMessageRequest request);

        Task<BatchDeleteMessageResponse> BatchDeleteMessageAsync(BatchDeleteMessageRequest request);

        #endregion

        #region  ReceiveMessage

        /// <summary>
        /// Retrieves one message from this queue.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// 
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage();

        Task<ReceiveMessageResponse> ReceiveMessageAsync();

        /// <summary>
        /// Retrieves one message.
        /// </summary>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage(uint waitSeconds);

        Task<ReceiveMessageResponse> ReceiveMessageAsync(uint waitSeconds);

        /// <summary>
        /// Retrieves one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS ReceiveMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage(ReceiveMessageRequest request);

        Task<ReceiveMessageResponse> ReceiveMessageAsync(ReceiveMessageRequest request);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize);

        Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(uint batchSize);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize, uint waitSeconds);

        Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(uint batchSize, uint waitSeconds);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(BatchReceiveMessageRequest request);

        Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(BatchReceiveMessageRequest request);

       
        #endregion

        #region  PeekMessage

        /// <summary>
        /// Peeks one message.
        /// </summary>
        /// 
        /// <returns>The response from the PeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        PeekMessageResponse PeekMessage();

        Task<PeekMessageResponse> PeekMessageAsync();

        /// <summary>
        /// Peeks one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS BatchPeekMessage service.</param>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        PeekMessageResponse PeekMessage(PeekMessageRequest request);

        Task<PeekMessageResponse>  PeekMessageAsync(PeekMessageRequest request);

        /// <summary>
        /// Peeks one message.
        /// </summary>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        BatchPeekMessageResponse BatchPeekMessage(uint batchSize);

        Task<BatchPeekMessageResponse> BatchPeekMessageAsync(uint batchSize);

        /// <summary>
        /// Peeks one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS BatchPeekMessage service.</param>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        BatchPeekMessageResponse BatchPeekMessage(BatchPeekMessageRequest request);

        Task<BatchPeekMessageResponse> BatchPeekMessageAsync(BatchPeekMessageRequest request);

        #endregion

        #region  SendMessage

        /// <summary>
        /// Delivers a message to the specified queue.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        SendMessageResponse SendMessage(string messageBody);

        Task<SendMessageResponse> SendMessageAsync(string messageBody);

        /// <summary>
        /// Send a message to this queue.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// <param name="delaySeconds">The message delay seconds.</param>
        /// <param name="priority">The message priority level.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SendMessageResponse SendMessage(string messageBody, uint delaySeconds, uint priority);

        Task<SendMessageResponse> SendMessageAsync(string messageBody, uint delaySeconds, uint priority);

        /// <summary>
        /// Send a message to this queue.
        /// </summary>
        /// <param name="request">The request object to be sent to MNS SendMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SendMessageResponse SendMessage(SendMessageRequest request);

        Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request);

        /// <summary>
        /// Batch send messages to this queue.
        /// </summary>
        /// <param name="request">The request objects to be sent to MNS SendMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="BatchSendFailException">
        /// some messages are not sent.
        /// </exception>
        BatchSendMessageResponse BatchSendMessage(BatchSendMessageRequest request);

        Task<BatchSendMessageResponse> BatchSendMessageAsync(BatchSendMessageRequest request);

       
        #endregion
    }
}
