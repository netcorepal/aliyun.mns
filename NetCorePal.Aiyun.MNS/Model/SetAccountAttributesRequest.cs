/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for request parameters that needed by MNS SetAccountAttributes service.
    /// </summary>
    public partial class SetAccountAttributesRequest : SimpleMNSRequest
    {
        private AccountAttributes _attributes = new AccountAttributes();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SetAccountAttributesRequest() { }

        /// <summary>
        /// Instantiates SetAccountAttributesRequest with the parameterized properties
        /// </summary>
        /// <param name="attributes">The account attributes to set.</param>
        public SetAccountAttributesRequest(AccountAttributes attributes)
        {
            _attributes = attributes;
        }

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
