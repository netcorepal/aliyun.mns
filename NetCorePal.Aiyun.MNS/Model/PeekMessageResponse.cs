/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS PeekMessage service
    /// </summary>
    public partial class PeekMessageResponse : WebServiceResponse
    {
        private Message _message = new Message();

        /// <summary>
        /// Gets and sets the property Message. 
        /// </summary>
        public Message Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
    }
}
