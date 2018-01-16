using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// DeleteMessage Request Marshaller
    /// </summary>       
    internal class DeleteMessageRequestMarshaller : IMarshaller<IRequest, DeleteMessageRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((DeleteMessageRequest)input);
        }
    
        public IRequest Marshall(DeleteMessageRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.DELETE.ToString();
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE + publicRequest.QueueName 
                + MNSConstants.MNS_MESSAGE_SUB_RESOURCE;
            PopulateSpecialParameters(publicRequest, request.Parameters);
            return request;
        }

        private void PopulateSpecialParameters(DeleteMessageRequest request, IDictionary<string, string> paramters)
        {
            if (request.IsSetReceiptHandle())
            {
                paramters.Add(MNSConstants.MNS_PARAMETER_RECEIPT_HANDLE, request.ReceiptHandle);
            }
        }
    }
}