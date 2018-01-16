/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS DeleteQueue service.
    /// </summary>
    public partial class DeleteQueueRequest : MNSRequest
    {
        private string _queueName;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public DeleteQueueRequest() { }

        /// <summary>
        /// Instantiates DeleteQueueRequest with the parameterized properties
        /// </summary>
        /// <param name="queueName">The queue name to take action on.</param>
        public DeleteQueueRequest(string queueName)
        {
            _queueName = queueName;
        }

        /// <summary>
        /// Gets and sets the property queueName. 
        /// <para>
        /// The queue name to take action on.
        /// </para>
        /// </summary>
        public string QueueName
        {
            get { return this._queueName; }
            set { this._queueName = value; }
        }

        // Check to see if queueName property is set
        internal bool IsSetQueueName()
        {
            return this._queueName != null;
        }

    }
}