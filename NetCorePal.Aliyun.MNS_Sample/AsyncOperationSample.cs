using Aliyun.MNS;
using Aliyun.MNS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCorePal.Aliyun.MNS_Sample
{
    /// <summary>
    /// Samples for all supported async operations of MNS.
    /// </summary>
    public class AsyncOperationSample
    {
        #region Private Properties

        private static string _accessKeyId = "<your access key id>";
        private static string _secretAccessKey = "<your secret access key>";
        private static string _endpoint = "<valid endpoint>";

       
        private const string _queueName = "myqueue2";
        private const string _queueNamePrefix = "xqueue";
        private const int _receiveTimes = 1;
        private const int _receiveInterval = 2;
        private const uint _batchSize = 6;
        private static string _receiptHandle;
        private static string _nextMarker = string.Empty;

        private static BatchReceiveMessageResponse _batchReceiveMessageResponse = null;

        #endregion

        #region Main Routine

        static void Main(string[] args)
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));
            _accessKeyId = config.AccessKeyId;
            _secretAccessKey = config.AccessKey;
            _endpoint = config.EndPoint;
            IMNS _client = new MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            #region Queue Releated Test Cases

            /* 1.1. Async create queue */
            var createQueueRequest = new CreateQueueRequest
            {
                QueueName = _queueName,
                Attributes =
                {
                    DelaySeconds = 10,
                    VisibilityTimeout = 30,
                    MaximumMessageSize = 40960,
                    MessageRetentionPeriod = 345600,
                    PollingWaitSeconds = 15
                }
            };

            try
            {
                var queue = _client.CreateQueueAsync(createQueueRequest).Result;
                Console.WriteLine("Async Create queue successfully, queue name: {0}", queue.QueueName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create queue failed, exception info: " + ex.Message);
            }


            /* 2.1 Async get queue attributes */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var getQueueAttributesRequest = new GetQueueAttributesRequest();

                var getQueueAttributesResponse = nativeQueue.GetAttributesAsync(getQueueAttributesRequest).Result;

                Console.WriteLine("Async Get queue attributes successfully, status code: {0}", getQueueAttributesResponse.HttpStatusCode);
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("QueueName: {0}", getQueueAttributesResponse.Attributes.QueueName);
                Console.WriteLine("CreateTime: {0}", getQueueAttributesResponse.Attributes.CreateTime);
                Console.WriteLine("LastModifyTime: {0}", getQueueAttributesResponse.Attributes.LastModifyTime);
                Console.WriteLine("VisibilityTimeout: {0}", getQueueAttributesResponse.Attributes.VisibilityTimeout);
                Console.WriteLine("MaximumMessageSize: {0}", getQueueAttributesResponse.Attributes.MaximumMessageSize);
                Console.WriteLine("MessageRetentionPeriod: {0}", getQueueAttributesResponse.Attributes.MessageRetentionPeriod);
                Console.WriteLine("DelaySeconds: {0}", getQueueAttributesResponse.Attributes.DelaySeconds);
                Console.WriteLine("PollingWaitSeconds: {0}", getQueueAttributesResponse.Attributes.PollingWaitSeconds);
                Console.WriteLine("InactiveMessages: {0}", getQueueAttributesResponse.Attributes.InactiveMessages);
                Console.WriteLine("ActiveMessages: {0}", getQueueAttributesResponse.Attributes.ActiveMessages);
                Console.WriteLine("DelayMessages: {0}", getQueueAttributesResponse.Attributes.DelayMessages);
                Console.WriteLine("----------------------------------------------------\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Get queue attributes failed, exception info: " + ex.Message);
            }


            /* 3. Async list queue */
            try
            {
                do
                {
                    var listQueueRequest = new ListQueueRequest
                    {
                        QueueNamePrefix = _queueNamePrefix,
                        Marker = _nextMarker,
                        MaxReturns = 5
                    };

                   var response= _client.ListQueueAsync(listQueueRequest).Result;

                    foreach (var queueUrl in response.QueueUrls)
                    {
                        Console.WriteLine(queueUrl);
                    }

                    Console.WriteLine("\n----------------------------------------------------\n");

                    if (response.IsSetNextMarker())
                    {
                        _nextMarker = response.NextMarker;
                        Console.WriteLine("NextMarker: {0}", response.NextMarker);
                    }
                    else
                    {
                        _nextMarker = string.Empty;
                    }


                } while (_nextMarker != string.Empty);

            }
            catch (Exception ex)
            {
                Console.WriteLine("List queue failed, exception info: " + ex.Message);
            }

            /* 4. Async set queue attributes */
            var setQueueAttributesRequest = new SetQueueAttributesRequest
            {
                Attributes =
                {
                    DelaySeconds = 0,
                    VisibilityTimeout = 10,
                    MaximumMessageSize = 10240,
                    PollingWaitSeconds = 10,
                    MessageRetentionPeriod = 50000
                }
            };
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);;
                var setQueueAttributesResponse=nativeQueue.SetAttributesAsync(setQueueAttributesRequest).Result;

                Console.WriteLine("Async Set queue attributes successfully, status code: {0}", setQueueAttributesResponse.HttpStatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Set queue attributes failed, exception info: " + ex.Message);
            }


            /* 2.2 Async get queue attributes again */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var getQueueAttributesRequest = new GetQueueAttributesRequest();
               var getQueueAttributesResponse = nativeQueue.GetAttributesAsync(getQueueAttributesRequest).Result;

                Console.WriteLine("Async Get queue attributes successfully, status code: {0}", getQueueAttributesResponse.HttpStatusCode);
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("QueueName: {0}", getQueueAttributesResponse.Attributes.QueueName);
                Console.WriteLine("CreateTime: {0}", getQueueAttributesResponse.Attributes.CreateTime);
                Console.WriteLine("LastModifyTime: {0}", getQueueAttributesResponse.Attributes.LastModifyTime);
                Console.WriteLine("VisibilityTimeout: {0}", getQueueAttributesResponse.Attributes.VisibilityTimeout);
                Console.WriteLine("MaximumMessageSize: {0}", getQueueAttributesResponse.Attributes.MaximumMessageSize);
                Console.WriteLine("MessageRetentionPeriod: {0}", getQueueAttributesResponse.Attributes.MessageRetentionPeriod);
                Console.WriteLine("DelaySeconds: {0}", getQueueAttributesResponse.Attributes.DelaySeconds);
                Console.WriteLine("PollingWaitSeconds: {0}", getQueueAttributesResponse.Attributes.PollingWaitSeconds);
                Console.WriteLine("InactiveMessages: {0}", getQueueAttributesResponse.Attributes.InactiveMessages);
                Console.WriteLine("ActiveMessages: {0}", getQueueAttributesResponse.Attributes.ActiveMessages);
                Console.WriteLine("DelayMessages: {0}", getQueueAttributesResponse.Attributes.DelayMessages);
                Console.WriteLine("----------------------------------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get queue attributes failed again, exception info: " + ex.Message);
            }


            /* 5.1. Async delete queue */
            var deleteQueueRequest = new DeleteQueueRequest(_queueName);
            deleteQueueRequest.AddHeader("Accept", "IE6");
            try
            {
                var response=_client.DeleteQueueAsync(deleteQueueRequest).Result;

                Console.WriteLine("Async Delete queue {0} successfully, status code: {1}", _queueName, response.HttpStatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete queue failed, exception info: " + ex.Message);
            }


            /* 1.2. Async create queue again */
            try
            {
                var queue=_client.CreateQueueAsync(createQueueRequest).Result;

                Console.WriteLine("Async Create queue successfully, queue name: {0}", queue.QueueName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create queue failed again, exception info: " + ex.Message);
            }


            #endregion

            #region Messge Releated Test Cases

            /* 5. Async receive message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                for (int i = 0; i < _receiveTimes; i++)
                {
                    var receiveMessageRequest = new ReceiveMessageRequest();                  
                    var response=nativeQueue.ReceiveMessageAsync(receiveMessageRequest).Result;
                    Console.WriteLine("Async Receive message successfully, status code: {0}", response.HttpStatusCode);
                    Console.WriteLine("----------------------------------------------------");
                    var message = response.Message;
                    Console.WriteLine("MessageId: {0}", message.Id);
                    Console.WriteLine("ReceiptHandle: {0}", message.ReceiptHandle);
                    Console.WriteLine("MessageBody: {0}", message.Body);
                    Console.WriteLine("MessageBodyMD5: {0}", message.BodyMD5);
                    Console.WriteLine("EnqueueTime: {0}", message.EnqueueTime);
                    Console.WriteLine("NextVisibleTime: {0}", message.NextVisibleTime);
                    Console.WriteLine("FirstDequeueTime: {0}", message.FirstDequeueTime);
                    Console.WriteLine("DequeueCount: {0}", message.DequeueCount);
                    Console.WriteLine("Priority: {0}", message.Priority);
                    Console.WriteLine("----------------------------------------------------\n");

                    _receiptHandle = message.ReceiptHandle;
   

                    Thread.Sleep(_receiveInterval);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Receive message failed, exception info: " + ex.Message);
            }

            /* 6. Async send message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var sendMessageRequest = new SendMessageRequest("阿里云计算");
                var response=nativeQueue.SendMessageAsync(sendMessageRequest).Result;
                Console.WriteLine("Async Send message successfully, status code: {0}, MessageBodyMD5: {1}",
                   response.MessageId, response.MessageBodyMD5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send message failed, exception info: " + ex.Message);
            }


            /* 7. Async receive message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                for (int i = 0; i < _receiveTimes; i++)
                {
                    var receiveMessageRequest = new ReceiveMessageRequest();
                    var response= nativeQueue.ReceiveMessageAsync(receiveMessageRequest).Result;
                    Console.WriteLine("Async Receive message successfully, status code: {0}", response.HttpStatusCode);
                    Console.WriteLine("----------------------------------------------------");
                    var message = response.Message;
                    Console.WriteLine("MessageId: {0}", message.Id);
                    Console.WriteLine("ReceiptHandle: {0}", message.ReceiptHandle);
                    Console.WriteLine("MessageBody: {0}", message.Body);
                    Console.WriteLine("MessageBodyMD5: {0}", message.BodyMD5);
                    Console.WriteLine("EnqueueTime: {0}", message.EnqueueTime);
                    Console.WriteLine("NextVisibleTime: {0}", message.NextVisibleTime);
                    Console.WriteLine("FirstDequeueTime: {0}", message.FirstDequeueTime);
                    Console.WriteLine("DequeueCount: {0}", message.DequeueCount);
                    Console.WriteLine("Priority: {0}", message.Priority);
                    Console.WriteLine("----------------------------------------------------\n");

                    _receiptHandle = message.ReceiptHandle;


                    Thread.Sleep(_receiveInterval);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Receive message failed, exception info: " + ex.Message);
            }

            /* 8. Async change message visibility */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var changeMessageVisibilityRequest = new ChangeMessageVisibilityRequest
                {
                    ReceiptHandle = _receiptHandle,
                    VisibilityTimeout = 5
                };
                var changeMessageVisibilityResponse=nativeQueue.ChangeMessageVisibilityAsync(changeMessageVisibilityRequest).Result;
                Console.WriteLine("Async Change message visibility successfully, ReceiptHandle: {0}, NextVisibleTime: {1}",
                   changeMessageVisibilityResponse.ReceiptHandle, changeMessageVisibilityResponse.NextVisibleTime);

                _receiptHandle = changeMessageVisibilityResponse.ReceiptHandle;

                Thread.Sleep(6000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Change message visibility failed, exception info: " + ex.Message);
            }

 

            /* 9. Async peek message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var peekMessageRequest = new PeekMessageRequest();
                for (uint i = 0; i < _receiveTimes; i++)
                {
                    var peekMessageResponse= nativeQueue.PeekMessageAsync(peekMessageRequest).Result;
                    Console.WriteLine("Async Peek message successfully, status code: {0}", peekMessageResponse.HttpStatusCode);
                    Console.WriteLine("----------------------------------------------------");
                    var message = peekMessageResponse.Message;
                    Console.WriteLine("MessageId: {0}", message.Id);
                    Console.WriteLine("MessageBody: {0}", message.Body);
                    Console.WriteLine("MessageBodyMD5: {0}", message.BodyMD5);
                    Console.WriteLine("EnqueueTime: {0}", message.EnqueueTime);
                    Console.WriteLine("FirstDequeueTime: {0}", message.FirstDequeueTime);
                    Console.WriteLine("DequeueCount: {0}", message.DequeueCount);
                    Console.WriteLine("Priority: {0}", message.Priority);
                    Console.WriteLine("----------------------------------------------------\n");


                    Thread.Sleep(_receiveInterval);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Peek message failed, exception info: " + ex.Message);
            }

            /* 10. Async delete message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var receiveMessageResponse = nativeQueue.ReceiveMessage();
                _receiptHandle = receiveMessageResponse.Message.ReceiptHandle;
                var deleteMessageRequest = new DeleteMessageRequest(_receiptHandle);
                var deleteMessageResponse=nativeQueue.DeleteMessageAsync(deleteMessageRequest).Result;
                Console.WriteLine("Async Delete message successfully, status code: {0}", deleteMessageResponse.HttpStatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Async BeginDeleteMessage failed, exception info: " + ex.Message);
            }



            /* 11. Async batch send message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                List<SendMessageRequest> requests = new List<SendMessageRequest>();
                requests.Add(new SendMessageRequest("阿里云计算 Priority1", 0, 1));
                for (int i = 0; i < _batchSize; i++)
                {
                    requests.Add(new SendMessageRequest("阿里云计算" + i.ToString()));
                }
                BatchSendMessageRequest batchSendRequest = new BatchSendMessageRequest()
                {
                    Requests = requests
                };
                var response=nativeQueue.BatchSendMessageAsync(batchSendRequest).Result;
                Console.WriteLine("Async Batch send message successfully, messages count {0}", response.Responses.Count);

 
            }
            catch (Exception ex)
            {
                Console.WriteLine("BeginBatchSend message failed, exception info: " + ex.Message);
            }

            Thread.Sleep(12000);

            /* 12. Async batch peek message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                var batchPeekMessageRequest = new BatchPeekMessageRequest(_batchSize + 2);
                Console.WriteLine(batchPeekMessageRequest.BatchSize.ToString());
                var batchPeekMessageResponse=nativeQueue.BatchPeekMessageAsync(batchPeekMessageRequest).Result;
                Console.WriteLine("Async Batch peek message successfully, status code: {0}, messages count {1}",
              batchPeekMessageResponse.HttpStatusCode, batchPeekMessageResponse.Messages.Count);


            }
            catch (Exception ex)
            {
                Console.WriteLine("BeginBatchPeek message failed, exception info: " + ex.Message);
            }

            /* 13. Async batch receive message */
            try
            {
                var nativeQueue = _client.GetNativeQueue(_queueName);
                BatchReceiveMessageRequest batchReceiveMessageRequest = new BatchReceiveMessageRequest(_batchSize + 1, 3);

                var _batchReceiveMessageResponse=nativeQueue.BatchReceiveMessageAsync(batchReceiveMessageRequest).Result;

                Console.WriteLine("Async Batch receive message successfully, status code: {0}, messages count {1}",
                   _batchReceiveMessageResponse.HttpStatusCode, _batchReceiveMessageResponse.Messages.Count);
                Console.WriteLine("----------------------------------------------------");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Batch receive message failed, exception info: " + ex.Message);
            }

            /* 14. Async batch delete message */
            if (_batchReceiveMessageResponse != null && _batchReceiveMessageResponse.Messages.Count > 0)
            {
                try
                {
                    var nativeQueue = _client.GetNativeQueue(_queueName);
                    List<string> receiptHandles = new List<string>();
                    foreach (var message in _batchReceiveMessageResponse.Messages)
                    {
                        receiptHandles.Add(message.ReceiptHandle);
                    }
                    var batchDeleteMessageRequest = new BatchDeleteMessageRequest()
                    {
                        ReceiptHandles = receiptHandles
                    };
                    var batchDeleteMessageResponse = nativeQueue.BatchDeleteMessageAsync(batchDeleteMessageRequest).Result;

                    Console.WriteLine("Async Batch delete message successfully, status code: {0}", batchDeleteMessageResponse.HttpStatusCode);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Batch delete message failed, exception info: " + ex.Message);
                }
            }

            #endregion

            #region Clean Generated Queue

            /* 5.2. Async delete queue again */
            try
            {
                var response=_client.DeleteQueueAsync(deleteQueueRequest).Result;

                Console.WriteLine("Async Delete queue {0} successfully, status code: {1}", deleteQueueRequest.QueueName, response.HttpStatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete queue failed again, exception info: " + ex.Message);
            }



            #endregion

            Console.ReadKey();
        }

        #endregion
    }
}
