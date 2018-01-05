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
    internal class GetAccountAttributesResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            AccountAttributes attributes = new AccountAttributes();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_LOGGING_BUCKET:
                                reader.Read();
                                attributes.LoggingBucket = reader.Value;
                                break;
                        }
                        break;
                }
            }
            reader.Close();
            return new GetAccountAttributesResponse()
            {
                Attributes = attributes
            };
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static GetAccountAttributesResponseUnmarshaller _instance = new GetAccountAttributesResponseUnmarshaller();        
        public static GetAccountAttributesResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}