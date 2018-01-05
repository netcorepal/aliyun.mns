using System.IO;
using System.Xml.Serialization;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// CreateQueue Request Marshaller
    /// </summary>       
    internal class CreateQueueRequestMarshaller : IMarshaller<IRequest, CreateQueueRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return Marshall((CreateQueueRequest)input);
        }

        public IRequest Marshall(CreateQueueRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(stream, System.Text.Encoding.UTF8);
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
            return request;
        }
    }
}