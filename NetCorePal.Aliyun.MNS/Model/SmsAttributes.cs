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
    public class SmsAttributes
    {
        private string _freeSignName;
        private string _templateCode;
        private string _extendCode;
        private string _extra;
        private Dictionary<string, string> _smsParams;
        private string _receiver;

        /// <summary>
        /// Gets and sets the property Receiver. 
        /// </summary>
        [DataMember]
        public string Receiver
        {
            get { return this._receiver; }
            set { this._receiver = value; }
        }

        // Check to see if Receiver property is set
        internal bool IsSetReceiver()
        {
            return this._receiver != null;
        }

        /// <summary>
        /// Gets and sets the property ExtendCode. 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ExtendCode
        {
            get { return this._extendCode; }
            set { this._extendCode = value; }
        }

        // Check to see if ExtendCode property is set
        internal bool IsSetExtendCode()
        {
            return this._extendCode != null;
        }

        /// <summary>
        /// Gets and sets the property Extra. 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Extra
        {
            get { return this._extra; }
            set { this._extra = value; }
        }

        // Check to see if Extra property is set
        internal bool IsSetExtra()
        {
            return this._extra != null;
        }

        /// <summary>
        /// Gets and sets the property FreeSignName. 
        /// </summary>
        [DataMember]
        public string FreeSignName
        {
            get { return this._freeSignName; }
            set { this._freeSignName = value; }
        }

        // Check to see if FreeSignName property is set
        internal bool IsSetFreeSignName()
        {
            return this._freeSignName != null;
        }

        /// <summary>
        /// Gets and sets the property TemplateCode. 
        /// </summary>
        [DataMember]
        public string TemplateCode
        {
            get { return this._templateCode; }
            set { this._templateCode = value; }
        }

        // Check to see if TemplateCode property is set
        internal bool IsSetTemplateCode()
        {
            return this._templateCode != null;
        }

        /// <summary>
        /// Gets and sets the property SmsParams. 
        /// </summary>
        public Dictionary<string, string> SmsParams
        {
            get { return this._smsParams; }
            set { this._smsParams = value; }
        }

        [DataMember(Name="SmsParams")]
        public string SmsParamsForJsonize
        {
            get
            {
                if (_smsParams.Count == 0)
                {
                    return "";
                }

                string[] entries = new string[_smsParams.Count];
                int index = 0;
                foreach (KeyValuePair<string, string> d in _smsParams)
                {
                    entries[index] = string.Format("\"{0}\": \"{1}\"", d.Key, d.Value);
                    index++;
                }
                return "{" + string.Join(",", entries) + "}";
            }
            set { }
        }

        // Check to see if SmsParams property is set
        internal bool IsSetSmsParams()
        {
            return this._smsParams != null;
        }

        public string ToJson()
        {
            using (MemoryStream s = new MemoryStream())
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(SmsAttributes));
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
