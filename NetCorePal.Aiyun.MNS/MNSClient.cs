/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Internal;
using Aliyun.MNS.Model;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal.Auth;
using Aliyun.MNS.Runtime.Pipeline;
using Aliyun.MNS.Runtime.Pipeline.Handlers;
using System.Threading.Tasks;
using NetCorePal.Aiyun.MNS.Util;

namespace Aliyun.MNS
{
    /// <summary>
    /// Implementation for accessing MNS
    /// </summary>
    public partial class MNSClient : AliyunServiceClient, IMNS
    {
        #region Constructors

        /// <summary>
        /// Constructs MNSClient with Aliyun Service Credentials.
        /// </summary>
        /// <param name="credentials">Aliyun Service Credentials</param>
        /// <param name="regionEndpoint">The region endpoint to connect.</param>
        public MNSClient(ServiceCredentials credentials, String regionEndpoint)
            : this(credentials, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) })
        {
        }

        /// <summary>
        /// Constructs MNSClient with Aliyun Service Credentials and an
        /// MNSClient Configuration object.
        /// </summary>
        /// <param name="credentials">Aliyun Service Credentials</param>
        /// <param name="clientConfig">The MNSClient Configuration Object</param>
        public MNSClient(ServiceCredentials credentials, MNSConfig clientConfig)
            : base(credentials, clientConfig)
        {
        }

        /// <summary>
        /// Constructs MNSClient with Aliyun Access Key ID and Aliyun Secret Key
        /// </summary>
        /// <param name="accessKeyId">Aliyun Access Key ID</param>
        /// <param name="secretAccessKey">Aliyun Secret Access Key</param>
        /// <param name="regionEndpoint">The region endpoint to connect. 
        /// http://$AccountID.mns.<region>.aliyuncs.com</param>
        public MNSClient(string accessKeyId, string secretAccessKey, string regionEndpoint)
			: this(accessKeyId, secretAccessKey, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) }, null)
        {
        }

		public MNSClient(string accessKeyId, string secretAccessKey, string regionEndpoint, string stsToken)
			: this(accessKeyId, secretAccessKey, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) }, stsToken)
		{
		}

        /// <summary>
        /// Constructs MNSClient with Aliyun Access Key ID, Secret Access Key and an
        /// MNSClient Configuration object. 
        /// </summary>
        /// <param name="accessKeyId">Aliyun Access Key ID</param>
        /// <param name="secretAccessKey">Aliyun Secret Access Key</param>
        /// <param name="clientConfig">The MNSClient Configuration Object</param>
        public MNSClient(string accessKeyId, string secretAccessKey, MNSConfig clientConfig, string stsToken)
			: base(accessKeyId, secretAccessKey, clientConfig, stsToken)
        {
        }

        #endregion

        #region Overrides

        protected override IServiceSigner CreateSigner()
        {
            return new MNSSigner();
        }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
        {
            pipeline.AddHandlerAfter<Marshaller>(new ResponseValidationHandler());
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region  CreateQueue

        /// <inheritdoc/>
        public Queue CreateQueue(string queueName)
        {
            return AggregateExceptionExtract.Extract(()=> 
            {
                return CreateQueueAsync(queueName).Result;
            });
           
        }

        public async Task<Queue> CreateQueueAsync(string queueName)
        {
            var request = new CreateQueueRequest { QueueName = queueName };
            return await CreateQueueAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Queue CreateQueue(CreateQueueRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return CreateQueueAsync(request).Result;
            });
           
        }

        public async Task<Queue> CreateQueueAsync(CreateQueueRequest request)
        {
            var marshaller = new CreateQueueRequestMarshaller();
            var unmarshaller = CreateQueueResponseUnmarshaller.Instance;

            var response =await InvokeAsync<CreateQueueRequest, CreateQueueResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
            return new Queue(response.QueueUrl.Substring(response.QueueUrl.LastIndexOf("/") + 1), this);
        }

       

        #endregion

        #region GetNativeQueue

        /// <inheritdoc/>
        public Queue GetNativeQueue(string queueName)
        {
            return new Queue(queueName, this);
        }

        #endregion

        #region  DeleteQueue

        /// <inheritdoc/>
        public DeleteQueueResponse DeleteQueue(string queueName)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteQueueAsync(queueName).Result;
            });
            
        }

        public async Task<DeleteQueueResponse> DeleteQueueAsync(string queueName)
        {
            var request = new DeleteQueueRequest { QueueName = queueName };
            return await DeleteQueueAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public DeleteQueueResponse DeleteQueue(DeleteQueueRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteQueueAsync(request).Result;
            });
           
        }

        public async Task<DeleteQueueResponse> DeleteQueueAsync(DeleteQueueRequest request)
        {
            var marshaller = new DeleteQueueRequestMarshaller();
            var unmarshaller = DeleteQueueResponseUnmarshaller.Instance;

            return  await InvokeAsync<DeleteQueueRequest, DeleteQueueResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }


        #endregion

        #region  ListQueue

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(string queueNamePrefix)
        {
            return AggregateExceptionExtract.Extract(()=> 
            {
                return ListQueueAsync(queueNamePrefix).Result;
            });
            
        }

        public async Task<ListQueueResponse> ListQueueAsync(string queueNamePrefix)
        {
            var request = new ListQueueRequest()
            {
                QueueNamePrefix = queueNamePrefix
            };
            return await ListQueueAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(string queueNamePrefix, string marker, uint maxReturns)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListQueueAsync(queueNamePrefix, marker, maxReturns).Result;
            });   
        }
        public async Task<ListQueueResponse> ListQueueAsync(string queueNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListQueueRequest()
            {
                QueueNamePrefix = queueNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return await ListQueueAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(ListQueueRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListQueueAsync(request).Result;
            });
          
        }

        public async Task<ListQueueResponse> ListQueueAsync(ListQueueRequest request)
        {
            var marshaller = new ListQueueRequestMarshaller();
            var unmarshaller = ListQueueResponseUnmarshaller.Instance;

            return await InvokeAsync<ListQueueRequest, ListQueueResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }


        #endregion

        #region  CreateTopic

        /// <inheritdoc/>
        public Topic CreateTopic(string topicName)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return CreateTopicAsync(topicName).Result;
            });
            
        }

        public async Task<Topic> CreateTopicAsync(string topicName)
        {
            var request = new CreateTopicRequest { TopicName = topicName };
            return await CreateTopicAsync(request).ConfigureAwait(false);
        }


        /// <inheritdoc/>
        public Topic CreateTopic(CreateTopicRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return CreateTopicAsync(request).Result;
            });
           
        }

       
        public async Task<Topic> CreateTopicAsync(CreateTopicRequest request)
        {
            var marshaller = new CreateTopicRequestMarshaller();
            var unmarshaller = CreateTopicResponseUnmarshaller.Instance;

            var response =await InvokeAsync<CreateTopicRequest, CreateTopicResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
            return new Topic(response.TopicUrl.Substring(response.TopicUrl.LastIndexOf("/") + 1), this);
        }

        #endregion

        #region GetNativeTopic

        /// <inheritdoc/>
        public Topic GetNativeTopic(string topicName)
        {
            return new Topic(topicName, this);
        }

        #endregion

        #region  DeleteTopic

        /// <inheritdoc/>
        public DeleteTopicResponse DeleteTopic(string topicName)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteTopicAsync(topicName).Result;
            });
            
        }

        public async Task<DeleteTopicResponse> DeleteTopicAsync(string topicName)
        {
            var request = new DeleteTopicRequest { TopicName = topicName };
            return await DeleteTopicAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public DeleteTopicResponse DeleteTopic(DeleteTopicRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return DeleteTopicAsync(request).Result;
            });
           
        }

        public async Task<DeleteTopicResponse> DeleteTopicAsync(DeleteTopicRequest request)
        {
            var marshaller = new DeleteTopicRequestMarshaller();
            var unmarshaller = DeleteTopicResponseUnmarshaller.Instance;

            return await InvokeAsync<DeleteTopicRequest, DeleteTopicResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region  ListTopic

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(string topicNamePrefix)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListTopicAsync(topicNamePrefix).Result;
            });
           
        }

        public async Task<ListTopicResponse> ListTopicAsync(string topicNamePrefix)
        {
            var request = new ListTopicRequest()
            {
                TopicNamePrefix = topicNamePrefix
            };
            return await ListTopicAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(string topicNamePrefix, string marker, uint maxReturns)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListTopicAsync(topicNamePrefix, marker, maxReturns).Result;
            });
            
        }

        public async Task<ListTopicResponse> ListTopicAsync(string topicNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListTopicRequest()
            {
                TopicNamePrefix = topicNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return await ListTopicAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(ListTopicRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return ListTopicAsync(request).Result;
            });
            
        }

        public async Task<ListTopicResponse> ListTopicAsync(ListTopicRequest request)
        {
            var marshaller = new ListTopicRequestMarshaller();
            var unmarshaller = ListTopicResponseUnmarshaller.Instance;

            return await InvokeAsync<ListTopicRequest, ListTopicResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region SetAccountAttributes

        /// <inheritdoc/>
        public SetAccountAttributesResponse SetAccountAttributes(AccountAttributes attributes)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAccountAttributesAsync(attributes).Result;
            });
           
        }

        public async Task<SetAccountAttributesResponse> SetAccountAttributesAsync(AccountAttributes attributes)
        {
            var request = new SetAccountAttributesRequest { Attributes = attributes };
            return await SetAccountAttributesAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public SetAccountAttributesResponse SetAccountAttributes(SetAccountAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return SetAccountAttributesAsync(request).Result;
            });
           
        }

        public async Task<SetAccountAttributesResponse> SetAccountAttributesAsync(SetAccountAttributesRequest request)
        {
            var marshaller = new SetAccountAttributesRequestMarshaller();
            var unmarshaller = SetAccountAttributesResponseUnmarshaller.Instance;

            return await InvokeAsync<SetAccountAttributesRequest, SetAccountAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);
        }

        #endregion

        #region GetAccountAttributes

        /// <inheritdoc/>
        public GetAccountAttributesResponse GetAccountAttributes()
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAccountAttributesAsync().Result;
            });
            
        }

        public async Task<GetAccountAttributesResponse> GetAccountAttributesAsync()
        {
            var request = new GetAccountAttributesRequest();
            return await GetAccountAttributesAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public GetAccountAttributesResponse GetAccountAttributes(GetAccountAttributesRequest request)
        {
            return AggregateExceptionExtract.Extract(() =>
            {
                return GetAccountAttributesAsync(request).Result;
            });
            
        }

        public async Task<GetAccountAttributesResponse> GetAccountAttributesAsync(GetAccountAttributesRequest request)
        {
            var marshaller = new GetAccountAttributesRequestMarshaller();
            var unmarshaller = GetAccountAttributesResponseUnmarshaller.Instance;

            return await InvokeAsync<GetAccountAttributesRequest, GetAccountAttributesResponse>(request, marshaller, unmarshaller).ConfigureAwait(false);

        }

        #endregion
    }
}
