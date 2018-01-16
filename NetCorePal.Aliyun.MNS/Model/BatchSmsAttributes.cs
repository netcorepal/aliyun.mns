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
    public class BatchSmsAttributes
    {
        private string _freeSignName;
        private string _templateCode;
        private string _extendCode;
        private string _extra;
        private Dictionary<string, Dictionary<string, string>> _smsParams;

        public BatchSmsAttributes()
        {
            this._smsParams = new Dictionary<string, Dictionary<string, string>>();
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
        /// Add Receiver with its SmsParams
        /// </summary>
        public void AddReceiver(string receiver, Dictionary<string, string> param)
        {
            this._smsParams.Add(receiver, param);
        }

        [DataMember(Name = "SmsParams")]
        public string SmsParamsForJsonize
        {
            get {
                if (_smsParams.Count == 0)
                {
                    return "";
                }
                return Newtonsoft.Json.JsonConvert.SerializeObject(_smsParams);
            }
            set { }
        }

        // Check to see if SmsParams property is set
        internal bool IsSetSmsParams()
        {
            return this._smsParams != null;
        }

        [DataMember]
        public string Type
        {
            get { return "multiContent"; }
            set { }
        }

        public string ToJson()
        {
            using (MemoryStream s = new MemoryStream())
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(BatchSmsAttributes));
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
