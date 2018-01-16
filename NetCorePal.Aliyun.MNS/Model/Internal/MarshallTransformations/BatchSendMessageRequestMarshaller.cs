using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    class BatchSendMessageRequestMarshaller : IMarshaller<IRequest, BatchSendMessageRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((BatchSendMessageRequest)input);
        }

        public IRequest Marshall(BatchSendMessageRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_MESSAGES, MNSConstants.MNS_XML_NAMESPACE);
            foreach (var sendMessageRequest in publicRequest.Requests)
            {
                writer.WriteStartElement(MNSConstants.XML_ROOT_MESSAGE);
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_BODY, sendMessageRequest.MessageBody);
                if (sendMessageRequest.IsSetDelaySeconds())
                {
                    writer.WriteElementString(MNSConstants.XML_ELEMENT_DELAY_SECONDS, sendMessageRequest.DelaySeconds.ToString());
                }
                if (sendMessageRequest.IsSetPriority())
                {
                    writer.WriteElementString(MNSConstants.XML_ELEMENT_PRIORITY, sendMessageRequest.Priority.ToString());
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
            request.ResourcePath = MNSConstants.MNS_MESSAGE_PRE_RESOURCE + publicRequest.QueueName
                + MNSConstants.MNS_MESSAGE_SUB_RESOURCE;
            return request;
        }
    }
}
