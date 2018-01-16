using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    class BatchPeekMessageResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            BatchPeekMessageResponse batchPeekMessageResponse = new BatchPeekMessageResponse();
            Message message = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ROOT_MESSAGE:
                                message = new Message();
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_ID:
                                reader.Read();
                                message.Id = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_BODY_MD5:
                                reader.Read();
                                message.BodyMD5 = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_BODY:
                                reader.Read();
                                message.Body = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_ENQUEUE_TIME:
                                reader.Read();
                                message.EnqueueTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value));
                                break;
                            case MNSConstants.XML_ELEMENT_FIRST_DEQUEUE_TIME:
                                reader.Read();
                                message.FirstDequeueTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value));
                                break;
                            case MNSConstants.XML_ELEMENT_DEQUEUE_COUNT:
                                reader.Read();
                                message.DequeueCount = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_PRIORITY:
                                reader.Read();
                                message.Priority = uint.Parse(reader.Value);
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == MNSConstants.XML_ROOT_MESSAGE)
                        {
                            batchPeekMessageResponse.Messages.Add(message);
                        }
                        break;
                }
            }
            reader.Close();
            return batchPeekMessageResponse;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.QueueNotExist))
            {
                return new QueueNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.MessageNotExist))
            {
                return new MessageNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static BatchPeekMessageResponseUnmarshaller _instance = new BatchPeekMessageResponseUnmarshaller();
        public static BatchPeekMessageResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
