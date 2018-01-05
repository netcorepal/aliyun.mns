using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public partial class BatchDeleteMessageRequest : SimpleMNSRequest
    {
        private List<string> _receiptHandles = new List<string>();

        /// <summary>
        /// Gets and sets the property ReceiptHandle. 
        /// </summary>
        public List<string> ReceiptHandles
        {
            get { return this._receiptHandles; }
            set { this._receiptHandles = value; }
        }

        public bool IsSetReceiptHandles()
        {
            return _receiptHandles.Any();
        }
    }
}
