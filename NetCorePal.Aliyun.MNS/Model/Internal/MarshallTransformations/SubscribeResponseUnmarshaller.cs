using System;
using System.Net;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for Subscribe operation
    /// </summary>  
    internal class SubscribeResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            var response = new SubscribeResponse();
            if (context.ResponseData.IsHeaderPresent(HttpHeader.LocationHeader))
                response.SubscriptionUrl = context.ResponseData.GetHeaderValue(HttpHeader.LocationHeader);
            return response;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.TopicNotExist))
            {
                return new TopicNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.SubscriptionNameLengthError))
            {
                return new SubscriptionNameLengthErrorException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.SubscriptionNameInvalid))
            {
                return new SubscriptionNameInvalidException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.SubscriptionAlreadyExist))
            {
                return new SubscriptionAlreadyExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.EndpointInvalid))
            {
                return new EndpointInvalidException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static SubscribeResponseUnmarshaller _instance = new SubscribeResponseUnmarshaller();
        public static SubscribeResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}