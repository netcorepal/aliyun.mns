using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System.Xml;
using System.Text;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// SetSubscriptionAttribute Request Marshaller
    /// </summary>       
    internal class SetSubscriptionAttributeRequestMarshaller : IMarshaller<IRequest, SetSubscriptionAttributeRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((SetSubscriptionAttributeRequest)input);
        }

        public IRequest Marshall(SetSubscriptionAttributeRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_SUBSCRIPTION, MNSConstants.MNS_XML_NAMESPACE);
            var attrs = publicRequest.Attributes;
            if (attrs.IsSetStrategy())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_NOTIFY_STRATEGY, attrs.Strategy.ToString());
            //if (attrs.IsSetContentFormat())
            //    writer.WriteElementString(MNSConstants.XML_ELEMENT_NOTIFY_CONTENT_FORMAT, attrs.ContentFormat.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.PUT.ToString();
            request.ContentStream = stream;
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName
                + MNSConstants.MNS_SUBSCRIBE_PRE_RESOURCE + publicRequest.SubscriptionName;
            PopulateSpecialParameters(request.Parameters);
            return request;
        }

        private static void PopulateSpecialParameters(IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_META_OVERRIDE, "true");
        }
    }
}