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
    /// Response Unmarshaller for GetTopicAttributes operation
    /// </summary>  
    internal class GetTopicAttributesResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            TopicAttributes attributes = new TopicAttributes();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_TOPIC_NAME:
                                reader.Read();
                                attributes.TopicName = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_CREATE_TIME:
                                reader.Read();
                                attributes.CreateTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value) * 1000);
                                break;
                            case MNSConstants.XML_ELEMENT_LAST_MODIFY_TIME:
                                reader.Read();
                                attributes.LastModifyTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value) * 1000);
                                break;
                            case MNSConstants.XML_ELEMENT_MAXIMUM_MESSAGE_SIZE:
                                reader.Read();
                                attributes.MaximumMessageSize = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_RETENTION_PERIOD:
                                reader.Read();
                                attributes.MessageRetentionPeriod = uint.Parse(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_COUNT:
                                reader.Read();
                                attributes.MessageCount = uint.Parse(reader.Value);
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
            return new GetTopicAttributesResponse()
            {
                Attributes = attributes
            };
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.TopicNotExist))
            {
                return new TopicNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static GetTopicAttributesResponseUnmarshaller _instance = new GetTopicAttributesResponseUnmarshaller();
        public static GetTopicAttributesResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}