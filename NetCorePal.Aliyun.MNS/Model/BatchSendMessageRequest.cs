using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public partial class BatchSendMessageRequest : SimpleMNSRequest
    {
        private List<SendMessageRequest> _requests;

        public List<SendMessageRequest> Requests
        {
            get { return this._requests; }
            set { this._requests = value; }
        }
    }
}
