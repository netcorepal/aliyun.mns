using System.IO;
using System.Xml.Serialization;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System;
using System.Text;
using System.Xml;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// PublishMessage Request Marshaller
    /// </summary>       
    internal class PublishMessageRequestMarshaller : IMarshaller<IRequest, PublishMessageRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((PublishMessageRequest)input);
        }

        public IRequest Marshall(PublishMessageRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_MESSAGE, MNSConstants.MNS_XML_NAMESPACE);
            if (publicRequest.IsSetMessageBody())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_BODY, publicRequest.MessageBody);
            if (publicRequest.IsSetMessageTag())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_TAG, publicRequest.MessageTag);
            if (publicRequest.IsSetMessageAttributes())
            {
                MessageAttributes messageAttributes = publicRequest.MessageAttributes;
                writer.WriteStartElement(MNSConstants.XML_ELEMENT_MESSAGE_ATTRIBUTES);
                if (messageAttributes.IsSetMailAttributes())
                {
                    MailAttributes mailAttributes = messageAttributes.MailAttributes;
                    writer.WriteElementString(MNSConstants.XML_ELEMENT_DIRECT_MAIL, mailAttributes.ToJson());
                }
                if (messageAttributes.IsSetSmsAttributes())
                {
                    SmsAttributes smsAttributes = messageAttributes.SmsAttributes;
                    writer.WriteElementString(MNSConstants.XML_ELEMENT_DIRECT_SMS, smsAttributes.ToJson());
                }
                if (messageAttributes.IsSetBatchSmsAttributes())
                {
                    BatchSmsAttributes batchSmsAttributes = messageAttributes.BatchSmsAttributes;
                    writer.WriteElementString(MNSConstants.XML_ELEMENT_DIRECT_SMS, batchSmsAttributes.ToJson());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

            stream.Seek(0, SeekOrigin.Begin);

            IRequest request = new DefaultRequest(publicRequest, MNSConstants.MNS_SERVICE_NAME);

            request.HttpMethod = HttpMethod.POST.ToString();
            request.ContentStream = stream;
            request.ResourcePath = MNSConstants.MNS_TOPIC_PRE_RESOURCE + publicRequest.TopicName
                + MNSConstants.MNS_MESSAGE_SUB_RESOURCE;
            return request;
        }
    }
}