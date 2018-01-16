using System.IO;
using System.Xml.Serialization;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Subscribe Request Marshaller
    /// </summary>       
    internal class SubscribeRequestMarshaller : IMarshaller<IRequest, SubscribeRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return Marshall((SubscribeRequest)input);
        }

        public IRequest Marshall(SubscribeRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(stream, System.Text.Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_SUBSCRIPTION, MNSConstants.MNS_XML_NAMESPACE);
            writer.WriteElementString(MNSConstants.XML_ELEMENT_ENDPOINT, publicRequest.EndPoint);
            if (publicRequest.IsSetFilterTag())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_FILTER_TAG, publicRequest.FilterTag);
            if (publicRequest.IsSetStrategy())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_NOTIFY_STRATEGY, publicRequest.Strategy.ToString());
            if (publicRequest.IsSetContentFormat())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_NOTIFY_CONTENT_FORMAT, publicRequest.ContentFormat.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.PUT.ToString();
            request.ContentStream = stream;
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName
                + MNSConstants.MNS_SUBSCRIBE_PRE_RESOURCE + publicRequest.SubscriptionName;
            return request;
        }
    }
}