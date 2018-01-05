using Aliyun.MNS;
using Aliyun.MNS.Model;
using Aliyun.MNS.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace NetCorePal.Aiyun.MNS.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private static string _accessKeyId = "<your access key id>";
        private static string _secretAccessKey = "<your secret access key>";
        private static string _endpoint = "<valid endpoint>";

        private IMNS client;

        public static string CalculateMD5(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            return CalculateMD5(messageBytes);
        }

        public static string CalculateMD5(byte[] bytes)
        {
            var md5Hash = CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(bytes);
            var calculatedMd5 = BitConverter.ToString(md5Hash).Replace("-", string.Empty).ToLower(CultureInfo.InvariantCulture);
            return calculatedMd5;
        }

        [SetUp]
        public void SetUp()
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));
            _accessKeyId = config.AccessKeyId;
            _secretAccessKey = config.AccessKey;
            _endpoint = config.EndPoint;
            client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            client.CreateQueue("UTQueue");
            try
            {
                client.DeleteQueue("UTQueue2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Test]
        public void SendDelaySecondsMessageTest()
        {
            Queue queue = client.GetNativeQueue("UTQueue");

            string messageBody = "test";
            string md5 = CalculateMD5(messageBody);
            var resp = queue.SendMessage(messageBody, 10, 8);
            Assert.AreEqual(resp.MessageBodyMD5.ToUpper(), md5.ToUpper());
        }

        [Test]
        public void SetAttributesTest()
        {
            Queue queue = client.GetNativeQueue("UTQueue");

            var resp = queue.GetAttributes();
            var originalLoggingEnabled = resp.Attributes.LoggingEnabled;

            QueueAttributes qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(originalLoggingEnabled, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = false };
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = true };
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = true };
            var req = new CreateQueueRequest() { QueueName = "UTQueue2", Attributes = qa };
            Queue queue2 = client.CreateQueue(req);
            resp = queue2.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            client.DeleteQueue("UTQueue2");

            qa = new QueueAttributes() { LoggingEnabled = false };
            req = new CreateQueueRequest() { QueueName = "UTQueue2", Attributes = qa };
            queue2 = client.CreateQueue(req);
            resp = queue2.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);
        }

        [TearDown]
        public void CleanUp()
        {
            client.DeleteQueue("UTQueue");
            try
            {
                client.DeleteQueue("UTQueue2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}
