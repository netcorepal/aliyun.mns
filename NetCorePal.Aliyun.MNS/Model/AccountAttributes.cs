using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model
{
    public class AccountAttributes
    {
        private string _loggingBucket = null;

        /// <summary>
        /// Gets and sets the property LoggingBucket. 
        /// </summary>
        public string LoggingBucket
        {
            get { return this._loggingBucket; }
            set { this._loggingBucket = value; }
        }

        // Check to see if LoggingBucket property is set
        internal bool IsSetLoggingBucket()
        {
            return this._loggingBucket != null;
        }
    }
}
