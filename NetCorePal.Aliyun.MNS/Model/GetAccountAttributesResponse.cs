/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using Aliyun.MNS.Runtime;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Response for MNS GetAccountAttributes service
    /// </summary>
    public partial class GetAccountAttributesResponse : WebServiceResponse
    {
        private AccountAttributes _attributes = new AccountAttributes();

        /// <summary>
        /// Gets and sets the property Attributes. 
        /// </summary>
        public AccountAttributes Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
        }
    }
}