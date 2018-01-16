using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// ListQueue Request Marshaller
    /// </summary>       
    internal class ListQueueRequestMarshaller : IMarshaller<IRequest, ListQueueRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((ListQueueRequest)input);
        }
    
        public IRequest Marshall(ListQueueRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.GET.ToString();
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE.Substring(0, MNSConstants.MNS_MESSAGE_PRE_RESOURCE.Length - 1);
            PopulateSpecialHeaders(publicRequest, request.Headers);
            return request;
        }

        private static void PopulateSpecialHeaders(ListQueueRequest publicRequest, IDictionary<string, string> headers)
        {
            if (publicRequest.IsSetQueueNamePrefix() && !string.IsNullOrEmpty(publicRequest.QueueNamePrefix))
                headers[HttpHeader.XMnsPrefixHeader] = publicRequest.QueueNamePrefix;
            if (publicRequest.IsSetMaxReturns())
                headers[HttpHeader.XMnsMaxReturnsHeader] = publicRequest.MaxReturns.ToString();
            if (publicRequest.IsSetMarker() && !string.IsNullOrEmpty(publicRequest.Marker))
                headers[HttpHeader.XMnsMarkerHeader] = publicRequest.Marker;
        }
    }
}