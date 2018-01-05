/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS SendMessage service
    /// </summary>
    public partial class SendMessageResponse : WebServiceResponse
    {
        private string _messageBodyMD5;
        private string _messageId;
        private string _receiptHandle;

        /// <summary>
        /// Gets and sets the property BodyMD5. 
        /// </summary>
        public string MessageBodyMD5
        {
            get { return this._messageBodyMD5; }
            set { this._messageBodyMD5 = value; }
        }

        // Check to see if BodyMD5 property is set
        internal bool IsSetMessageBodyMD5()
        {
            return this._messageBodyMD5 != null;
        }

        /// <summary>
        /// Gets and sets the property MessageId. 
        /// </summary>
        public string MessageId
        {
            get { return this._messageId; }
            set { this._messageId = value; }
        }

        // Check to see if MessageId property is set
        internal bool IsSetMessageId()
        {
            return this._messageId != null;
        }

        /// <summary>
        /// Gets and sets the property ReceiptHandle. 
        /// </summary>
        public string ReceiptHandle
        {
            get { return this._receiptHandle; }
            set { this._receiptHandle = value; }
        }

        // Check to see if ReceiptHandle property is set
        internal bool IsSetReceiptHandle()
        {
            return this._receiptHandle != null;
        }

        public override string ToString()
        {
            return string.Format("(MessageId {0}, MessageBodyMD5 {1}, ReceiptHandle {2})", _messageId, _messageBodyMD5, _receiptHandle);
        }
    }
}
