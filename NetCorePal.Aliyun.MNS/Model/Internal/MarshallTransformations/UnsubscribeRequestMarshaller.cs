using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// DeleteTopic Request Marshaller
    /// </summary>       
    internal class UnsubscribeRequestMarshaller : IMarshaller<IRequest, UnsubscribeRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((UnsubscribeRequest)input);
        }

        public IRequest Marshall(UnsubscribeRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.DELETE.ToString();
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName
                + MNSConstants.MNS_SUBSCRIBE_PRE_RESOURCE + publicRequest.SubscriptionName;
            return request;
        }
    }
}