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
    /// SendMessage Request Marshaller
    /// </summary>       
    internal class SendMessageRequestMarshaller : IMarshaller<IRequest, SendMessageRequest>, IMarshaller<IRequest, WebServiceRequest>
    {
        public IRequest Marshall(WebServiceRequest input)
        {
            return this.Marshall((SendMessageRequest)input);
        }
    
        public IRequest Marshall(SendMessageRequest publicRequest)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement(MNSConstants.XML_ROOT_MESSAGE, MNSConstants.MNS_XML_NAMESPACE);
            if (publicRequest.IsSetMessageBody())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_MESSAGE_BODY, publicRequest.MessageBody);
            if (publicRequest.IsSetDelaySeconds())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_DELAY_SECONDS, publicRequest.DelaySeconds.ToString());
            if (publicRequest.IsSetPriority())
                writer.WriteElementString(MNSConstants.XML_ELEMENT_PRIORITY, publicRequest.Priority.ToString());
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