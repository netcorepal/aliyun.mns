using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    class BatchPeekMessageRequestMarshaller : IMarshaller<IRequest, BatchPeekMessageRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((BatchPeekMessageRequest)input);
        }

        public IRequest Marshall(BatchPeekMessageRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.GET.ToString();
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE + publicRequest.QueueName
                + MNSConstants.MNS_MESSAGE_SUB_RESOURCE;
            PopulateSpecialParameters(publicRequest, request.Parameters);
            return request;
        }

        private static void PopulateSpecialParameters(BatchPeekMessageRequest request, IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_PEEK_ONLY, "true");
            paramters.Add(MNSConstants.MNS_PARAMETER_BATCH_SIZE, request.BatchSize.ToString());
        }
    }
}
