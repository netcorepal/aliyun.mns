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
    public partial class SendMessageRequest : SimpleMNSRequest
    {
        private string _messageBody;
        private uint? _delaySeconds;
        private uint? _priority;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SendMessageRequest() { }

        /// <summary>
        /// Instantiates SendMessageRequest with the parameterized properties
        /// </summary>
        /// <param name="messageBody">The message to send. </param>
        public SendMessageRequest(string messageBody)
        {
            _messageBody = messageBody;
        }

        /// <summary>
        /// Instantiates SendMessageRequest with the parameterized properties
        /// </summary>
        /// <param name="messageBody">The message to send. </param>
        /// <param name="delaySeconds">The message's delay seconds. </param>
        /// <param name="priority">The message's priority level. </param>
        public SendMessageRequest(string messageBody, uint delaySeconds, uint priority)
        {
            _messageBody = messageBody;
            _delaySeconds = delaySeconds;
            _priority = priority;
        }

        /// <summary>
        /// Gets and sets the property DelaySeconds. 
        /// </summary>
        public uint DelaySeconds
        {
            get { return this._delaySeconds.GetValueOrDefault(MNSConstants.DEFAULT_DELAY_SECONDS); }
            set { this._delaySeconds = value; }
        }

        // Check to see if DelaySeconds property is set
        internal bool IsSetDelaySeconds()
        {
            return this._delaySeconds.HasValue; 
        }

        /// <summary>
        /// Gets and sets the property Priority. 
        /// </summary>
        public uint Priority
        {
            get { return this._priority.GetValueOrDefault(MNSConstants.DEFAULT_MESSAGE_PRIORITY); }
            set { this._priority = value; }
        }

        // Check to see if Priority property is set
        internal bool IsSetPriority()
        {
            return this._priority.HasValue;
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

    }
}
