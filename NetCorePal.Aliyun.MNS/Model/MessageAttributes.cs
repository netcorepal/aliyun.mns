/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Util;

namespace Aliyun.MNS.Model
{
    /// <summary>
    /// Container for a set of queue attributes.
    /// </summary>
    public partial class MessageAttributes
    {
        private MailAttributes _mailAttributes;
        private SmsAttributes _smsAttributes;
        private BatchSmsAttributes _batchSmsAttributes;

        /// <summary>
        /// Gets and sets the property MailAttributes. 
        /// </summary>
        public MailAttributes MailAttributes
        {
            get { return this._mailAttributes; }
            set { this._mailAttributes = value; }
        }

        // Check to see if MailAttributes property is set
        public bool IsSetMailAttributes()
        {
            return this._mailAttributes != null;
        }

        /// <summary>
        /// Gets and sets the property SmsAttributes. 
        /// </summary>
        public SmsAttributes SmsAttributes
        {
            get { return this._smsAttributes; }
            set { this._smsAttributes = value; }
        }

        // Check to see if SmsAttributes property is set
        public bool IsSetSmsAttributes()
        {
            return this._smsAttributes != null;
        }

        /// <summary>
        /// Gets and sets the property BatchSmsAttributes. 
        /// </summary>
        public BatchSmsAttributes BatchSmsAttributes
        {
            get { return this._batchSmsAttributes; }
            set { this._batchSmsAttributes = value; }
        }

        // Check to see if BatchSmsAttributes property is set
        public bool IsSetBatchSmsAttributes()
        {
            return this._batchSmsAttributes != null;
        }
    }
}
