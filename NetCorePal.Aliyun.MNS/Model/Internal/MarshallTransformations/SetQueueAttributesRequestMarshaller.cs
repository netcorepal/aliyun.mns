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
    /// SetQueueAttributes Request Marshaller
    /// </summary>       
    internal class SetQueueAttributesRequestMarshaller : IMarshaller<IRequest, SetQueueAttributesRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((SetQueueAttributesRequest)input);
        }
    
        public IRequest Marshall(SetQueueAttributesRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_QUEUE, MNSConstants.MNS_XML_NAMESPACE);
            var attrs = publicRequest.Attributes;
            if (attrs.IsSetDelaySeconds())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_DELAY_SECONDS, attrs.DelaySeconds.ToString());
            if (attrs.IsSetMaximumMessageSize())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MAXIMUM_MESSAGE_SIZE, attrs.MaximumMessageSize.ToString());
            if (attrs.IsSetMessageRetentionPeriod())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_RETENTION_PERIOD, attrs.MessageRetentionPeriod.ToString());
            if (attrs.IsSetVisibilityTimeout())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_VISIBILITY_TIMEOUT, attrs.VisibilityTimeout.ToString());
            if (attrs.IsSetPollingWaitSeconds())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_POLLING_WAIT_SECONDS, attrs.PollingWaitSeconds.ToString());
            if (attrs.IsSetLoggingEnabled())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_LOGGING_ENABLED, attrs.LoggingEnabled.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);
            request.HttpMethod = HttpMethod.PUT.ToString();
            request.ContentStream = stream;
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE + publicRequest.QueueName;
            PopulateSpecialParameters(request.Parameters);
            return request;
        }

        private static Stream MarshallInternal(SetQueueAttributesRequest request)
        {
            var xmlRequest = new XmlSetQueueAttributesRequest();

            var attrs = request.Attributes;
            if (attrs.IsSetDelaySeconds())
                xmlRequest.DelaySeconds = attrs.DelaySeconds;
            if (attrs.IsSetMaximumMessageSize())
                xmlRequest.MaximumMessageSize = attrs.MaximumMessageSize;
            if (attrs.IsSetMessageRetentionPeriod())
                xmlRequest.MessageRetentionPeriod = attrs.MessageRetentionPeriod;
            if (attrs.IsSetVisibilityTimeout())
                xmlRequest.VisibilityTimeout = attrs.VisibilityTimeout;
            if (attrs.IsSetPollingWaitSeconds())
                xmlRequest.PollingWaitSeconds = attrs.PollingWaitSeconds;

            var marshaller = new XmlMarshaller<XmlSetQueueAttributesRequest>();
            return marshaller.Marshall(xmlRequest);
        }

        private static void PopulateSpecialParameters(IDictionary<string, string> paramters)
        {
            paramters.Add(MNSConstants.MNS_PARAMETER_META_OVERRIDE, "true");
        }
    }

    [XmlRoot(MNSConstants.XML_ROOT_QUEUE, Namespace = MNSConstants.MNS_XML_NAMESPACE)]
    public class XmlSetQueueAttributesRequest
    {
        [XmlElement(MNSConstants.ATTRIBUTE_DELAY_SECONDS, IsNullable = true)]
        public uint? DelaySeconds { get; set; }

        public bool ShouldSerializeDelaySeconds()
        {
            return DelaySeconds.HasValue;
        }

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

        [XmlElement(MNSConstants.ATTRIBUTE_VISIBILITY_TIMEOUT, IsNullable = true)]
        public uint? VisibilityTimeout { get; set; }

        public bool ShouldSerializeVisibilityTimeout()
        {
            return VisibilityTimeout.HasValue;
        }

        [XmlElement(MNSConstants.ATTRIBUTE_POLLING_WAIT_SECONDS, IsNullable = true)]
        public uint? PollingWaitSeconds { get; set; }

        public bool ShouldSerializePollingWaitSeconds()
        {
            return PollingWaitSeconds.HasValue;
        }
    }
}