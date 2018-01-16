using System.Collections.Generic;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// ListSubscription Request Marshaller
    /// </summary>       
    internal class ListSubscriptionRequestMarshaller : IMarshaller<IRequest, ListSubscriptionRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((ListSubscriptionRequest)input);
        }

        public IRequest Marshall(ListSubscriptionRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.GET.ToString();
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName
                + MNSConstants.MNS_SUBSCRIBE_PRE_RESOURCE.Substring(0, MNSConstants.MNS_SUBSCRIBE_PRE_RESOURCE.Length - 1);
            PopulateSpecialHeaders(publicRequest, request.Headers);
            return request;
        }

        private static void PopulateSpecialHeaders(ListSubscriptionRequest publicRequest, IDictionary<string, string> headers)
        {
            if (publicRequest.IsSetSubscriptionNamePrefix() && !string.IsNullOrEmpty(publicRequest.SubscriptionNamePrefix))
                headers[HttpHeader.XMnsPrefixHeader] = publicRequest.SubscriptionNamePrefix;
            if (publicRequest.IsSetMaxReturns())
                headers[HttpHeader.XMnsMaxReturnsHeader] = publicRequest.MaxReturns.ToString();
            if (publicRequest.IsSetMarker() && !string.IsNullOrEmpty(publicRequest.Marker))
                headers[HttpHeader.XMnsMarkerHeader] = publicRequest.Marker;
        }
    }
}