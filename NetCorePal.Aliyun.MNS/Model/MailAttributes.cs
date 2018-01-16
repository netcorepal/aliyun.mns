using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Aliyun.MNS.Model
{
    [DataContract()]
    public class MailAttributes
    {
        // please refer to https://help.aliyun.com/document_detail/directmail/api-reference/sendmail-related/SingleSendMail.html
        private string _subject;
        private string _accountName;
        private bool _replyToAddress = false;
        private int _addressType = 0;
        private bool _isHtml = false;

        /// <summary>
        /// Gets and sets the property Subject. 
        /// </summary>
        [DataMember]
        public string Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }

        // Check to see if Subject property is set
        internal bool IsSetSubject()
        {
            return this._subject != null;
        }

        /// <summary>
        /// Gets and sets the property AccountName. 
        /// </summary>
        [DataMember]
        public string AccountName
        {
            get { return this._accountName; }
            set { this._accountName = value; }
        }

        // Check to see if AccountName property is set
        internal bool IsSetAccountName()
        {
            return this._accountName != null;
        }

        /// <summary>
        /// Gets and sets the property ReplyToAddress. 
        /// </summary>
        public bool ReplyToAddress
        {
            get { return this._replyToAddress; }
            set { this._replyToAddress = value; }
        }

        [DataMember(Name = "ReplyToAddress")]
        public int ReplyToAddressForJsonize
        {
            get { return this._replyToAddress ? 1 : 0; }
            private set { }
        }

        /// <summary>
        /// Gets and sets the property AddressType. 
        /// </summary>
        [DataMember]
        public int AddressType
        {
            get { return this._addressType; }
            set { this._addressType = value; }
        }

        /// <summary>
        /// Gets and sets the property IsHtml. 
        /// </summary>
        public bool IsHtml
        {
            get { return this._isHtml; }
            set { this._isHtml = value; }
        }

        [DataMember(Name = "IsHtml")]
        public int IsHtmlForJsonize
        {
            get { return this._isHtml ? 1 : 0; }
            private set { }
        }

        public string ToJson()
        {
            using (MemoryStream s = new MemoryStream())
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(MailAttributes));
                dataContractJsonSerializer.WriteObject(s, this);
                s.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(s))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
