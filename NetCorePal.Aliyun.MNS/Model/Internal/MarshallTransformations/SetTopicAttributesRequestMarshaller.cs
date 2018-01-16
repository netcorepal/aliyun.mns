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
    /// SetTopicAttributes Request Marshaller
    /// </summary>       
    internal class SetTopicAttributesRequestMarshaller : IMarshaller<IRequest, SetTopicAttributesRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((SetTopicAttributesRequest)input);
        }

        public IRequest Marshall(SetTopicAttributesRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_TOPIC, MNSConstants.MNS_XML_NAMESPACE);
            var attrs = publicRequest.Attributes;
            if (attrs.IsSetMaximumMessageSize())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MAXIMUM_MESSAGE_SIZE, attrs.MaximumMessageSize.ToString());
            if (attrs.IsSetMessageRetentionPeriod())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_RETENTION_PERIOD, attrs.MessageRetentionPeriod.ToString());
            if (attrs.IsSetLoggingEnabled())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_LOGGING_ENABLED, attrs.LoggingEnabled.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.PUT.ToString();
            request.ContentStream = stream;
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName;
            PopulateSpecialParameters(request.Parameters);
            return request;
        }

        private static Stream MarshallInternal(SetTopicAttributesRequest request)
        {
            var xmlRequest = new XmlSetTopicAttributesRequest();

            var attrs = request.Attributes;
            if (attrs.IsSetMaximumMessageSize())
                xmlRequest.MaximumMessageSize = attrs.MaximumMessageSize;
            if (attrs.IsSetMessageRetentionPeriod())
                xmlRequest.MessageRetentionPeriod = attrs.MessageRetentionPeriod;
            
            var marshaller = new XmlMarshaller<XmlSetTopicAttributesRequest>();
            return marshaller.Marshall(xmlRequest);
        }

        private static void PopulateSpecialParameters(IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_META_OVERRIDE, "true");
        }
    }

    [XmlRoot(MNSConstants.XML_ROOT_TOPIC, Namespace = MNSConstants.MNS_XML_NAMESPACE)]
    public class XmlSetTopicAttributesRequest
    {
        [XmlElement(MNSConstants.ATTRIBUTE_MAXIMUM_MESSAGE_SIZE, IsNullable = true)]
        public uint? MaximumMessageSize { get; set; }

        public bool ShouldSerializeMaximumMessageSize()
        {
            return MaximumMessageSize.HasValue;
        }

        [XmlElement(MNSConstants.ATTRIBUTE_MESSAGE_RETENTION_PERIOD, IsNullable = true)]
        public uint? MessageRetentionPeriod { get; set; }

        public bool ShouldSerializeMessageRetentionPeriod()
        {
            return MessageRetentionPeriod.HasValue;
        }
    }
}