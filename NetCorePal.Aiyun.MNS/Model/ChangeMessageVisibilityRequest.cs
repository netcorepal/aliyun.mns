/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS ChangeMessageVisibility service.
    /// </summary>
    public partial class ChangeMessageVisibilityRequest : SimpleMNSRequest
    {
        private string _receiptHandle;
        private int _visibilityTimeout;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ChangeMessageVisibilityRequest() { }

        /// <summary>
        /// Instantiates ChangeMessageVisibilityRequest with the parameterized properties
        /// </summary>
        /// <param name="receiptHandle">The receipt handle associated with the message whose visibility timeout should be changed.</param>
        /// <param name="visibilityTimeout">The new value for the message's visibility timeout.</param>
        public ChangeMessageVisibilityRequest(string receiptHandle, int visibilityTimeout)
        {
            _receiptHandle = receiptHandle;
            _visibilityTimeout = visibilityTimeout;
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

        /// <summary>
        /// Gets and sets the property VisibilityTimeout. 
        /// </summary>
        public int VisibilityTimeout
        {
            get { return this._visibilityTimeout; }
            set { this._visibilityTimeout = value; }
        }

    }
}