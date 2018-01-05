using Aliyun.MNS.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public class BatchSendFailException : AliyunServiceException
    {
        private List<BatchSendErrorItem> _errorItems = new List<BatchSendErrorItem>();
        private List<SentMessageResponse> _sentMessageResponses = new List<SentMessageResponse>();

        public BatchSendFailException() : base(MNSErrorCode.BatchSendFail)
        {
            this.ErrorCode = MNSErrorCode.BatchSendFail;
        }

        public List<BatchSendErrorItem> ErrorItems
        {
            get { return this._errorItems; }
            set { this._errorItems = value; }
        }

        public List<SentMessageResponse> SentMessageResponses
        {
            get { return this._sentMessageResponses; }
            set { this._sentMessageResponses = value; }
        }
    }

    public class SentMessageResponse
    {
        private string _messageId;
        private string _messageBodyMd5;

        public SentMessageResponse()
        {
        }

        public SentMessageResponse(string messageId, string messageBodyMd5)
        {
            this._messageId = messageId;
            this._messageBodyMd5 = messageBodyMd5;
        }

        public override string ToString()
        {
            return string.Format("MessageId is {0}, MessageBodyMd5 is {1}",
                _messageId, _messageBodyMd5);
        }

        public string MessageId
        {
            get { return this._messageId; }
            set { this._messageId = value; }
        }

        public string MessageBodyMd5
        {
            get { return this._messageBodyMd5; }
            set { this._messageBodyMd5 = value; }
        }
    }

    public class BatchSendErrorItem
    {
        private string _errorCode;
        private string _errorMessage;

        public BatchSendErrorItem()
        {
        }

        public BatchSendErrorItem(string errorCode, string errorMessage)
        {
            this._errorCode = errorCode;
            this._errorMessage = errorMessage;
        }

        public override string ToString()
        {
            return string.Format("ErrorCode is {0}, ErrorMessage is {1}",
                _errorCode, _errorMessage);
        }

        public string ErrorCode
        {
            get { return this._errorCode; }
            set { this._errorCode = value; }
        }

        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }
    }
}
