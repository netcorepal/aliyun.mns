using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// ListTopic Request Marshaller
    /// </summary>       
    internal class ListTopicRequestMarshaller : IMarshaller<IRequest, ListTopicRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((ListTopicRequest)input);
        }

        public IRequest Marshall(ListTopicRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.GET.ToString();
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE.Substring(0, MNSConstants.MNS_TOPIC_PRE_RESOURCE.Length - 1);
            PopulateSpecialHeaders(publicRequest, request.Headers);
            return request;
        }

        private static void PopulateSpecialHeaders(ListTopicRequest publicRequest, IDictionary<string, string> headers)
        {
            if (publicRequest.IsSetTopicNamePrefix() && !string.IsNullOrEmpty(publicRequest.TopicNamePrefix))
                headers[HttpHeader.XMnsPrefixHeader] = publicRequest.TopicNamePrefix;
            if (publicRequest.IsSetMaxReturns())
                headers[HttpHeader.XMnsMaxReturnsHeader] = publicRequest.MaxReturns.ToString();
            if (publicRequest.IsSetMarker() && !string.IsNullOrEmpty(publicRequest.Marker))
                headers[HttpHeader.XMnsMarkerHeader] = publicRequest.Marker;
        }
    }
}