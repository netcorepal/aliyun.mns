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
    /// Response Unmarshaller for ListSubscription operation
    /// </summary>  
    internal class ListSubscriptionResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            ListSubscriptionResponse response = new ListSubscriptionResponse();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_SUBSCRIPTION_URL:
                                reader.Read();
                                response.SubscriptionUrls.Add(reader.Value);
                                break;
                            case MNSConstants.XML_ELEMENT_NEXT_MARKER:
                                reader.Read();
                                response.NextMarker = reader.Value;
                                break;
                        }
                        break;
                }
            }
            reader.Close();
            return response;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static ListSubscriptionResponseUnmarshaller _instance = new ListSubscriptionResponseUnmarshaller();
        public static ListSubscriptionResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}