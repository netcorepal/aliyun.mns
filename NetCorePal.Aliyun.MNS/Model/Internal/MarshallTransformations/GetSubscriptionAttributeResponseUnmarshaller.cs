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
    /// Response Unmarshaller for GetSubscriptionAttribute operation
    /// </summary>  
    internal class GetSubscriptionAttributeResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            SubscriptionAttributes attributes = new SubscriptionAttributes();

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
                            case MNSConstants.XML_ELEMENT_TOPIC_OWNER:
                                reader.Read();
                                attributes.TopicOwner = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_SUBSCRIPTION_NAME:
                                reader.Read();
                                attributes.SubscriptionName = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_ENDPOINT:
                                reader.Read();
                                attributes.EndPoint = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_NOTIFY_STRATEGY:
                                reader.Read();
                                string strategyStr = reader.Value;
                                attributes.Strategy = (SubscriptionAttributes.NotifyStrategy) 
                                    Enum.Parse(typeof(SubscriptionAttributes.NotifyStrategy), strategyStr.ToUpper());
                                break;
                            case MNSConstants.XML_ELEMENT_NOTIFY_CONTENT_FORMAT:
                                reader.Read();
                                string contentFormatStr = reader.Value;
                                attributes.ContentFormat = (SubscriptionAttributes.NotifyContentFormat)
                                    Enum.Parse(typeof(SubscriptionAttributes.NotifyContentFormat), contentFormatStr.ToUpper());
                                break;
                        }
                        break;
                }
            }
            reader.Close();
            return new GetSubscriptionAttributeResponse()
            {
                Attributes = attributes
            };
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.SubscriptionNotExist))
            {
                return new SubscriptionNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static GetSubscriptionAttributeResponseUnmarshaller _instance = new GetSubscriptionAttributeResponseUnmarshaller();
        public static GetSubscriptionAttributeResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}