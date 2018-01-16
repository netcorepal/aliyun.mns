using Aliyun.MNS.Runtime.Internal.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.MNS.Runtime;
using System.Net;
using Aliyun.MNS.Util;
using System.Xml.Serialization;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime.Internal;
using System.IO;
using System.Xml;

namespace Aliyun.MNS.Model.Internal.MarshallTransformations
{
    class BatchSendMessageResponseUnmarshaller : XmlResponseUnmarshaller
    {
        public override WebServiceResponse Unmarshall(XmlUnmarshallerContext context)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);
            BatchSendMessageResponse batchSendMessageResponse = new BatchSendMessageResponse();
            SendMessageResponse messageResponse = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ROOT_MESSAGE:
                                messageResponse = new SendMessageResponse();
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_ID:
                                reader.Read();
                                messageResponse.MessageId = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_BODY_MD5:
                                reader.Read();
                                messageResponse.MessageBodyMD5 = reader.Value;
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == MNSConstants.XML_ROOT_MESSAGE)
                        {
                            batchSendMessageResponse.Responses.Add(messageResponse);
                        }
                        break;
                }
            }
            reader.Close();
            return batchSendMessageResponse;
        }

        public override AliyunServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            XmlTextReader reader = new XmlTextReader(context.ResponseStream);

            ErrorResponse errorResponse = new ErrorResponse();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.LocalName == MNSConstants.XML_ROOT_ERROR_RESPONSE)
                        {
                            return UnmarshallNormalError(reader, innerException, statusCode);
                        }
                        else
                        {
                            return UnmarshallBatchSendError(reader);
                        }
                }
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private BatchSendFailException UnmarshallBatchSendError(XmlTextReader reader)
        {
            BatchSendFailException batchSendFailException = new BatchSendFailException();
            BatchSendErrorItem errorItem = null;
            SentMessageResponse responseItem = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.LocalName)
                        {
                            case MNSConstants.XML_ELEMENT_ERROR_CODE:
                                if (errorItem == null)
                                {
                                    errorItem = new BatchSendErrorItem();
                                }
                                reader.Read();
                                errorItem.ErrorCode = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_ERROR_MESSAGE:
                                if (errorItem == null)
                                {
                                    errorItem = new BatchSendErrorItem();
                                }
                                reader.Read();
                                errorItem.ErrorMessage = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_ID:
                                if (responseItem == null)
                                {
                                    responseItem = new SentMessageResponse();
                                }
                                reader.Read();
                                responseItem.MessageId = reader.Value;
                                break;
                            case MNSConstants.XML_ELEMENT_MESSAGE_BODY_MD5:
                                if (responseItem == null)
                                {
                                    responseItem = new SentMessageResponse();
                                }
                                reader.Read();
                                responseItem.MessageBodyMd5 = reader.Value;
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == MNSConstants.XML_ROOT_MESSAGE)
                        {
                            if (errorItem != null)
                            {
                                batchSendFailException.ErrorItems.Add(errorItem);
                                errorItem = null;
                            }
                            else if (responseItem != null)
                            {
                                batchSendFailException.SentMessageResponses.Add(responseItem);
                                responseItem = null;
                            }
                        }
                        break;
                }
            }
            reader.Close();
            return batchSendFailException;
        }

        private AliyunServiceException UnmarshallNormalError(XmlTextReader reader, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.Instance.Unmarshall(reader);
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.QueueNotExist))
            {
                return new QueueNotExistException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.MalformedXML))
            {
                return new MalformedXMLException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals(MNSErrorCode.InvalidArgument))
            {
                return new InvalidArgumentException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
            }
            return new MNSException(errorResponse.Message, innerException, errorResponse.Code, errorResponse.RequestId, errorResponse.HostId, statusCode);
        }

        private static BatchSendMessageResponseUnmarshaller _instance = new BatchSendMessageResponseUnmarshaller();
        public static BatchSendMessageResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
