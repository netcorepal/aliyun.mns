using Aliyun.MNS.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePal.Aiyun.MNS.Tests.Model
{
    [TestFixture]
    public class BatchSmsAttributesTests
    {
        [Test]
        public void ToJsonTest()
        {
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            batchSmsAttributes.FreeSignName = "111";
            batchSmsAttributes.TemplateCode = "222";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("name", "3\"555\"33");
            batchSmsAttributes.AddReceiver("444", param);

            Assert.AreEqual(
                "{\"FreeSignName\":\"111\",\"SmsParams\":\"{\\\"444\\\":{\\\"name\\\":\\\"3\\\\\\\"555\\\\\\\"33\\\"}}\",\"TemplateCode\":\"222\",\"Type\":\"multiContent\"}",
                batchSmsAttributes.ToJson());
        }
    }
}
