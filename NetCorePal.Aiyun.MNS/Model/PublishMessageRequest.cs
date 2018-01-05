/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS SendMessage service.
    /// </summary>
    public partial class PublishMessageRequest : SimpleMNSRequest
    {
        private string _messageBody;
        private string _messageTag;
        private MessageAttributes _messageAttributes;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public PublishMessageRequest() { }

        /// <summary>
        /// Instantiates PublishMessageRequest with the parameterized properties
        /// </summary>
        /// <param name="messageBody">The message to send. </param>
        public PublishMessageRequest(string messageBody)
            : this(messageBody, null)
        {
        }

        /// <summary>
        /// Instantiates PublishMessageRequest with the parameterized properties
        /// </summary>
        /// <param name="messageBody">The message to send. </param>
        /// <param name="messageTag">The MessageTag related. </param>
        public PublishMessageRequest(string messageBody, string messageTag)
        {
            _messageBody = messageBody;
            _messageTag = messageTag;
        }

        /// <summary>
        /// Gets and sets the property MessageBody. 
        /// </summary>
        public string MessageBody
        {
            get { return this._messageBody; }
            set { this._messageBody = value; }
        }

        // Check to see if MessageBody property is set
        internal bool IsSetMessageBody()
        {
            return this._messageBody != null;
        }

        /// <summary>
        /// Gets and sets the property MessageTag. 
        /// </summary>
        public string MessageTag
        {
            get { return this._messageTag; }
            set { this._messageTag = value; }
        }

        // Check to see if MessageTag property is set
        internal bool IsSetMessageTag()
        {
            return this._messageTag != null;
        }

        /// <summary>
        /// Gets and sets the property MessageAttributes. 
        /// </summary>
        public MessageAttributes MessageAttributes
        {
            get { return this._messageAttributes; }
            set { this._messageAttributes = value; }
        }

        // Check to see if MessageAttributes property is set
        internal bool IsSetMessageAttributes()
        {
            return this._messageAttributes != null;
        }

    }
}
