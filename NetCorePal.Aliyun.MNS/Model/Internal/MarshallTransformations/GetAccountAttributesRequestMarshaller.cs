using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// GetQueueAttributes Request Marshaller
    /// </summary>       
    internal class GetAccountAttributesRequestMarshaller : IMarshaller<IRequest, GetAccountAttributesRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((GetAccountAttributesRequest)input);
        }
    
        public IRequest Marshall(GetAccountAttributesRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.GET.ToString();
            request.ResourcePath = "";
            PopulateSpecialParameters(request.Parameters);
            return request;
        }

        private static void PopulateSpecialParameters(IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_ACCOUNT_META, "true");
        }
    }
}