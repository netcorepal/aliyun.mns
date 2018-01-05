using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// ChangeMessageVisibility Request Marshaller
    /// </summary>       
    internal class ChangeMessageVisibilityRequestMarshaller : IMarshaller<IRequest, ChangeMessageVisibilityRequest> , IMarshaller<IRequest,WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((ChangeMessageVisibilityRequest)input);
        }
    
        public IRequest Marshall(ChangeMessageVisibilityRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.PUT.ToString();
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE + publicRequest.QueueName
                + MNSConstants.MNS_MESSAGE_SUB_RESOURCE;
            PopulateSpecialParameters(publicRequest, request.Parameters);
            return request;
        }

        private static void PopulateSpecialParameters(ChangeMessageVisibilityRequest request, IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_RECEIPT_HANDLE, request.ReceiptHandle);
            paramters.Add(MNSConstants.MNS_PARAMETER_VISIBILITY_TIMEOUT, request.VisibilityTimeout.ToString());
        }
    }
}