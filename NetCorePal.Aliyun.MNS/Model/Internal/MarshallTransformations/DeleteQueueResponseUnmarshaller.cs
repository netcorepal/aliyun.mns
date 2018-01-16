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
    internal class DeleteQueueResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            DeleteQueueResponse response = new DeleteQueueResponse();
            // Nothing need to do with this response here
            return response;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static DeleteQueueResponseUnmarshaller _instance = new DeleteQueueResponseUnmarshaller();        
        public static DeleteQueueResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}