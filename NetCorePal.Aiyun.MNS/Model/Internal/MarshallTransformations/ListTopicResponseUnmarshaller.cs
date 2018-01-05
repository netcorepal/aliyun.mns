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
    /// Response Unmarshaller for ListTopic operation
    /// </summary>  
    internal class ListTopicResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            ListTopicResponse response = new ListTopicResponse();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_TOPIC_URL:
                                reader.Read();
                                response.TopicUrls.Add(reader.Value);
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

        private static ListTopicResponseUnmarshaller _instance = new ListTopicResponseUnmarshaller();
        public static ListTopicResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}