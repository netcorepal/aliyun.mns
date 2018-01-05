/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS CreateQueue service.
    /// </summary>
    public partial class CreateQueueRequest : MNSRequest
    {
        private QueueAttributes _attributes = new QueueAttributes();
        private string _queueName;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public CreateQueueRequest() { }

        /// <summary>
        /// Instantiates CreateQueueRequest with the parameterized properties
        /// </summary>
        /// <param name="queueName">The name for the queue to be created.</param>
        /// <param name="attributes">The queue attributes to be set.</param>
        public CreateQueueRequest(string queueName, QueueAttributes attributes)
        {
            _queueName = queueName;
            _attributes = attributes;
        }

        /// <summary>
        /// Gets and sets the property Attributes. 
        /// </summary>
        public QueueAttributes Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
        }

        /// <summary>
        /// Gets and sets the property QueueName. 
        /// </summary>
        public string QueueName
        {
            get { return this._queueName; }
            set { this._queueName = value; }
        }

        // Check to see if QueueName property is set
        internal bool IsSetQueueName()
        {
            return this._queueName != null;
        }

    }
}