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
    /// Response Unmarshaller for ChangeMessageVisibility operation
    /// </summary>  
    internal class ChangeMessageVisibilityResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            ChangeMessageVisibilityResponse response = new ChangeMessageVisibilityResponse();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_RECEIPT_HANDLE:
                                reader.Read();
                                response.ReceiptHandle = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_NEXT_VISIBLE_TIME:
                                reader.Read();
                                response.NextVisibleTime = AliyunSDKUtils.ConvertFromUnixEpochSeconds(long.Parse(reader.Value));
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
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.QueueNotExist))
            {
                return new QueueNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.InvalidArgument))
            {
                return new InvalidArgumentException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.MessageNotExist))
            {
                return new MessageNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static ChangeMessageVisibilityResponseUnmarshaller _instance = new ChangeMessageVisibilityResponseUnmarshaller();        
        public static ChangeMessageVisibilityResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}