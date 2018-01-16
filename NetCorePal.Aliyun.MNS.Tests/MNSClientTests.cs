using Aliyun.MNS;
using Aliyun.MNS.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCorePal.Aliyun.MNS.Tests
{
    [TestFixture]
    public class MNSClientTests
    {
        private static string _accessKeyId = "<your access key id>";
        private static string _secretAccessKey = "<your secret access key>";
        private static string _endpoint = "<valid endpoint>";

        [Test]
        public void SetAccountAttributesTest()
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));
            _accessKeyId = config.AccessKeyId;
            _secretAccessKey = config.AccessKey;
            _endpoint = config.EndPoint;

            IMNS client = new MNSClient(_accessKeyId, _secretAccessKey, _endpoint);

            var resp = client.GetAccountAttributes();
            var originalLoggingBucket = resp.Attributes.LoggingBucket;

            AccountAttributes aa1 = new AccountAttributes();
            client.SetAccountAttributes(aa1);
            resp = client.GetAccountAttributes();
            Assert.AreEqual(originalLoggingBucket, resp.Attributes.LoggingBucket);

            AccountAttributes aa2 = new AccountAttributes() { LoggingBucket = "Test" };
            client.SetAccountAttributes(aa2);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa3 = new AccountAttributes();
            client.SetAccountAttributes(aa3);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa4 = new AccountAttributes() { LoggingBucket = "Test" };
            client.SetAccountAttributes(aa4);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa5 = new AccountAttributes() { LoggingBucket = "" };
            client.SetAccountAttributes(aa5);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("", resp.Attributes.LoggingBucket);
        }
    }
}
