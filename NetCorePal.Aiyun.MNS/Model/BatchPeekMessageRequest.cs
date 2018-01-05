using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public partial class BatchPeekMessageRequest : SimpleMNSRequest
    {
        private uint _batchSize;

        public uint BatchSize
        {
            get { return this._batchSize; }
            set { this._batchSize = value; }
        }

        public BatchPeekMessageRequest(uint batchSize)
        {
            _batchSize = batchSize;
        }
    }
}
