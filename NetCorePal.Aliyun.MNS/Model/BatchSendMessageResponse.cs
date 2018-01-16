using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public partial class BatchSendMessageResponse : WebServiceResponse
    {
        private List<SendMessageResponse> _responses = new List<SendMessageResponse>();

        public List<SendMessageResponse> Responses
        {
            get { return this._responses; }
            set { this._responses = value; }
        }
    }
}
