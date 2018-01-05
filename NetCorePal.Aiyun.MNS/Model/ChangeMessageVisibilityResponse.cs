/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS ChangeMessageVisibility service
    /// </summary>
    public partial class ChangeMessageVisibilityResponse : WebServiceResponse
    {
        private string _receiptHandle;
        private DateTime _nextVisibleTime;

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
        /// Gets and sets the property NextVisibleTime. 
        /// </summary>
        public DateTime NextVisibleTime
        {
            get { return this._nextVisibleTime; }
            set { this._nextVisibleTime = value; }
        }
    }
}