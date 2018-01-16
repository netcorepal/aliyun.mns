/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System.Collections.Generic;
using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS ListQueue service
    /// </summary>
    public partial class ListQueueResponse : WebServiceResponse
    {
        private List<string> _queueUrls = new List<string>();
        private string _nextMarker;

        /// <summary>
        /// Gets and sets the property QueueUrls. 
        /// </summary>
        public List<string> QueueUrls
        {
            get { return this._queueUrls; }
            set { this._queueUrls = value; }
        }

        // Check to see if QueueUrls property is set
        public bool IsSetQueueUrls()
        {
            return this._queueUrls != null && this._queueUrls.Count > 0;
        }

        /// <summary>
        /// Gets and sets the property NextMarker. 
        /// </summary>
        public string NextMarker
        {
            get { return this._nextMarker; }
            set { this._nextMarker = value; }
        }

        // Check to see if NextMarker property is set
        public bool IsSetNextMarker()
        {
            return this._nextMarker != null;
        }
    }
}