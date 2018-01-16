using System;
using System.Net;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for DeleteQueue operation
    /// </summary>  
    internal class UnsubscribeResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            UnsubscribeResponse response = new UnsubscribeResponse();
            // Nothing need to do with this response here
            return response;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static UnsubscribeResponseUnmarshaller _instance = new UnsubscribeResponseUnmarshaller();
        public static UnsubscribeResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}