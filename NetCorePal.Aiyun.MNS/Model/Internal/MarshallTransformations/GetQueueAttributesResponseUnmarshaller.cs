using System;
using System.Net;
using System.Xml.Serialization;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System.Xml;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for GetQueueAttributes operation
    /// </summary>  
    internal class GetQueueAttributesResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            QueueAttributes attributes = new QueueAttributes();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_QUEUE_NAME:
                                reader.Read();
                                attributes.QueueName = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_CREATE_TIME:
                                reader.Read();
                                attributes.CreateTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value) * 1000);
                                break;
                            case MNSConstants.XML_ELEMENT_LAST_MODIFY_TIME:
                                reader.Read();
                                attributes.LastModifyTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value) * 1000);
                                break;
                            case MNSConstants.XML_ELEMENT_VISIBILITY_TIMEOUT:
                                reader.Read();
                                attributes.VisibilityTimeout = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_MAXIMUM_MESSAGE_SIZE:
                                reader.Read();
                                attributes.MaximumMessageSize = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_RETENTION_PERIOD:
                                reader.Read();
                                attributes.MessageRetentionPeriod = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_DELAY_SECONDS:
                                reader.Read();
                                attributes.DelaySeconds = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_POLLING_WAIT_SECONDS:
                                reader.Read();
                                attributes.PollingWaitSeconds = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_INACTIVE_MESSAGES:
                                reader.Read();
                                attributes.InactiveMessages = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_ACTIVE_MESSAGES:
                                reader.Read();
                                attributes.ActiveMessages = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.ATTRIBUTE_DELAY_MESSAGES:
                                reader.Read();
                                attributes.DelayMessages = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_LOGGING_ENABLED:
                                reader.Read();
                                attributes.LoggingEnabled = bool.Parse(reader.Value);
                                break;
                        }
                        break;
                }
            }
            reader.Close();
            return new GetQueueAttributesResponse()
            {
                Attributes = attributes
            };
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.QueueNotExist))
            {
                return new QueueNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static GetQueueAttributesResponseUnmarshaller _instance = new GetQueueAttributesResponseUnmarshaller();        
        public static GetQueueAttributesResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}