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
using NetCorePal.Aiyun.MNS.Util;

namespace Aliyun.MNS
{
    /// <summary>
    /// Implementation for accessing MNS queue
    /// </summary>
    public partial class Queue : IQueue
    {
        #region Properties

        private string _queueName;
        private readonly AliyunServiceClient _serviceClient;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates Queue with the parameterized properties
        /// </summary>
        public Queue(string queueName, AliyunServiceClient serviceClient)
        {
            _queueName = queueName;
            _serviceClient = serviceClient;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets and sets the property QueueName
        /// </summary>
        public string QueueName
        {
            get { return this._queueName; }
            set { this._queueName = value; }
        }

        /// <summary>
        /// Check to see if QueueName property is set
        /// </summary>
        public bool IsSetQueueName()
        {
            return this._queueName != null;
        }

        #endregion

        #region  GetAttributes

        /// <inheritdoc/>
        public GetQueueAttributesResponse GetAttributes()
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAttributesAsync().Result;
            });
           
        }

        public async Task<GetQueueAttributesResponse> GetAttributesAsync()
        {
            var request = new GetQueueAttributesRequest();
            return await GetAttributesAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public GetQueueAttributesResponse GetAttributes(GetQueueAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAttributesAsync(request).Result;
            });
           
        }

        public async Task<GetQueueAttributesResponse> GetAttributesAsync(GetQueueAttributesRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new GetQueueAttributesRequestMarshaller();
            var unmarshaller = GetQueueAttributesResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<GetQueueAttributesRequest, GetQueueAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);

        }
        

        #endregion

        #region  SetAttributes

        /// <inheritdoc/>
        public SetQueueAttributesResponse SetAttributes(QueueAttributes attributes)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAttributesAsync(attributes).Result;
            });
           
        }

        public async Task<SetQueueAttributesResponse> SetAttributesAsync(QueueAttributes attributes)
        {
            var request = new SetQueueAttributesRequest { Attributes = attributes };
            return await SetAttributesAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public SetQueueAttributesResponse SetAttributes(SetQueueAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAttributesAsync(request).Result;
            });
           
        }

      
        public async Task<SetQueueAttributesResponse> SetAttributesAsync(SetQueueAttributesRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SetQueueAttributesRequestMarshaller();
            var unmarshaller = SetQueueAttributesResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<SetQueueAttributesRequest, SetQueueAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  ChangeMessageVisibility

        /// <inheritdoc/>
        public ChangeMessageVisibilityResponse ChangeMessageVisibility(string receiptHandle, int visibilityTimeout)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ChangeMessageVisibilityAsync(receiptHandle, visibilityTimeout).Result;
            });
           
        }

        public async Task<ChangeMessageVisibilityResponse> ChangeMessageVisibilityAsync(string receiptHandle, int visibilityTimeout)
        {
            var request = new ChangeMessageVisibilityRequest()
            {
                ReceiptHandle = receiptHandle,
                VisibilityTimeout = visibilityTimeout
            };
            return await ChangeMessageVisibilityAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public ChangeMessageVisibilityResponse ChangeMessageVisibility(ChangeMessageVisibilityRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ChangeMessageVisibilityAsync(request).Result;
            });
           
        }
       
        public async Task<ChangeMessageVisibilityResponse> ChangeMessageVisibilityAsync(ChangeMessageVisibilityRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ChangeMessageVisibilityRequestMarshaller();
            var unmarshaller = ChangeMessageVisibilityResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<ChangeMessageVisibilityRequest, ChangeMessageVisibilityResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }
      

        #endregion

        #region DeleteMessage

        /// <inheritdoc/>
        public DeleteMessageResponse DeleteMessage(string receiptHandle)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteMessageAsync(receiptHandle).Result;
            });
           
        }

        public async Task<DeleteMessageResponse> DeleteMessageAsync(string receiptHandle)
        {
            var request = new DeleteMessageRequest { ReceiptHandle = receiptHandle };
            return await DeleteMessageAsync(request).ConfigureAwait(false);

        }

        /// <inheritdoc/>
        public DeleteMessageResponse DeleteMessage(DeleteMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteMessageAsync(request).Result;
            });
            
        }

        public async Task<DeleteMessageResponse> DeleteMessageAsync(DeleteMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new DeleteMessageRequestMarshaller();
            var unmarshaller = DeleteMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<DeleteMessageRequest, DeleteMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchDeleteMessageResponse BatchDeleteMessage(BatchDeleteMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchDeleteMessageAsync(request).Result;
            });
            
        }

        public async Task<BatchDeleteMessageResponse> BatchDeleteMessageAsync(BatchDeleteMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchDeleteMessageRequestMarshaller();
            var unmarshaller = BatchDeleteMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<BatchDeleteMessageRequest, BatchDeleteMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region ReceiveMessage

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage()
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ReceiveMessageAsync().Result;
            });
           
        }

        public async Task<ReceiveMessageResponse> ReceiveMessageAsync()
        {
            var request = new ReceiveMessageRequest();
            return await ReceiveMessageAsync(request).ConfigureAwait(false);

        }

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage(uint waitSeconds)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ReceiveMessageAsync(waitSeconds).Result;
            });
           
        }

        public async Task<ReceiveMessageResponse> ReceiveMessageAsync(uint waitSeconds)
        {
            var request = new ReceiveMessageRequest() { WaitSeconds = waitSeconds };
            return await ReceiveMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage(ReceiveMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ReceiveMessageAsync(request).Result;
            });
            
        }

        public async Task<ReceiveMessageResponse> ReceiveMessageAsync(ReceiveMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ReceiveMessageRequestMarshaller();
            var unmarshaller = ReceiveMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<ReceiveMessageRequest, ReceiveMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchReceiveMessageAsync(batchSize).Result;
            });
            
        }

        public async Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(uint batchSize)
        {
            var request = new BatchReceiveMessageRequest(batchSize);
            return await BatchReceiveMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize, uint waitSeconds)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchReceiveMessageAsync(batchSize, waitSeconds).Result;
            });
            
        }

        public async Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(uint batchSize, uint waitSeconds)
        {
            var request = new BatchReceiveMessageRequest(batchSize, waitSeconds);
            return await BatchReceiveMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(BatchReceiveMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchReceiveMessageAsync(request).Result;
            });
           
        }

        public async Task<BatchReceiveMessageResponse> BatchReceiveMessageAsync(BatchReceiveMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchReceiveMessageRequestMarshaller();
            var unmarshaller = BatchReceiveMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<BatchReceiveMessageRequest, BatchReceiveMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  PeekMessage

        /// <inheritdoc/>
        public PeekMessageResponse PeekMessage()
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return PeekMessageAsync().Result;
            });
            
        }

        public async Task<PeekMessageResponse> PeekMessageAsync()
        {
            var request = new PeekMessageRequest();
            return await PeekMessageAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public PeekMessageResponse PeekMessage(PeekMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return PeekMessageAsync(request).Result;
            });
           
        }
       
        public async Task<PeekMessageResponse> PeekMessageAsync(PeekMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new PeekMessageRequestMarshaller();
            var unmarshaller = PeekMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<PeekMessageRequest, PeekMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }
        /// <inheritdoc/>
        public BatchPeekMessageResponse BatchPeekMessage(uint batchSize)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchPeekMessageAsync(batchSize).Result;
            });
            
        }

        public async Task<BatchPeekMessageResponse> BatchPeekMessageAsync(uint batchSize)
        {
            var request = new BatchPeekMessageRequest(batchSize);
            return await BatchPeekMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchPeekMessageResponse BatchPeekMessage(BatchPeekMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchPeekMessageAsync(request).Result;
            });
            
        }

        public async Task<BatchPeekMessageResponse> BatchPeekMessageAsync(BatchPeekMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchPeekMessageRequestMarshaller();
            var unmarshaller = BatchPeekMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<BatchPeekMessageRequest, BatchPeekMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region SendMessage

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(string messageBody)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SendMessageAsync(messageBody).Result;
            });
           
        }

        public async Task<SendMessageResponse> SendMessageAsync(string messageBody)
        {
            var request = new SendMessageRequest { MessageBody = messageBody };
            return await SendMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(string messageBody, uint delaySeconds, uint priority)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SendMessageAsync(messageBody, delaySeconds, priority).Result;
            });
           
        }

        public async Task<SendMessageResponse> SendMessageAsync(string messageBody, uint delaySeconds, uint priority)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = messageBody,
                DelaySeconds = delaySeconds,
                Priority = priority
            };
            return await SendMessageAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(SendMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SendMessageAsync(request).Result;
            });
           
        }

        public async Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SendMessageRequestMarshaller();
            var unmarshaller = SendMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<SendMessageRequest, SendMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public BatchSendMessageResponse BatchSendMessage(BatchSendMessageRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return BatchSendMessageAsync(request).Result;
            });
            
        }

        public async Task<BatchSendMessageResponse> BatchSendMessageAsync(BatchSendMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchSendMessageRequestMarshaller();
            var unmarshaller = BatchSendMessageResponseUnmarshaller.Instance;

            return await _serviceClient.InvokeAsync<BatchSendMessageRequest, BatchSendMessageResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

       
        #endregion
    }
}
