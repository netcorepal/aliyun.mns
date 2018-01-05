/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS PublishMessage service
    /// </summary>
    public partial class PublishMessageResponse : WebServiceResponse
    {
        private string _messageBodyMD5;
        private string _messageId;

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

        public override string ToString()
        {
            return string.Format("(MessageId {0}, MessageBodyMD5 {1})", _messageId, _messageBodyMD5);
        }
    }
}
