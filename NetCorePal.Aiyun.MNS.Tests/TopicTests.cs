using Aliyun.MNS;
using Aliyun.MNS.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCorePal.Aiyun.MNS.Tests
{
    [TestFixture]
    public class TopicTests
    {
        private static string _accessKeyId = "<your access key id>";
        private static string _secretAccessKey = "<your secret access key>";
        private static string _endpoint = "<valid endpoint>";

        private IMNS client;

        [SetUp]
        public void SetUp()
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));
            _accessKeyId = config.AccessKeyId;
            _secretAccessKey = config.AccessKey;
            _endpoint = config.EndPoint;
            client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            client.CreateTopic("UTTopic");
            try
            {
                client.DeleteTopic("UTTopic2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Test]
        public void SetAttributesTest()
        {
            Topic topic = client.GetNativeTopic("UTTopic");

            var resp = topic.GetAttributes();
            var originalLoggingEnabled = resp.Attributes.LoggingEnabled;

            TopicAttributes qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(originalLoggingEnabled, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = false };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = true };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = false };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = true };
            var req = new CreateTopicRequest() { TopicName = "UTTopic2", Attributes = qa };
            Topic topic2 = client.CreateTopic(req);
            resp = topic2.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            client.DeleteTopic("UTTopic2");

            qa = new TopicAttributes() { LoggingEnabled = false };
            req = new CreateTopicRequest() { TopicName = "UTTopic2", Attributes = qa };
            topic2 = client.CreateTopic(req);
            resp = topic2.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);
        }

        [TearDown]
        public void CleanUp()
        {
            client.DeleteTopic("UTTopic");
            try
            {
                client.DeleteTopic("UTTopic2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}
