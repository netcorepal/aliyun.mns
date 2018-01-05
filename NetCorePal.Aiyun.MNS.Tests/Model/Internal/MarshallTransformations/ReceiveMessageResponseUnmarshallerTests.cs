using Aliyun.MNS.Model;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCorePal.Aiyun.MNS.Tests.Model.Internal.MarshallTransformations
{
    [TestFixture]
    public class ReceiveMessageResponseUnmarshallerTests
    {
        [Test]
        public void UnmarshallTest()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Message xmlns = \"http://mns.aliyuncs.com/doc/v1/\">\n<MessageId>5F290C926D472878-2-14D9529A8FA-200000001</MessageId><ReceiptHandle>1-ODU4OTkzNDU5My0xNDMyNzI3ODI3LTItOA==</ReceiptHandle><MessageBodyMD5>C5DD56A39F5F7BB8B3337C6D11B6D8C7</MessageBodyMD5><MessageBody>This is a test message</MessageBody><EnqueueTime>1250700979248</EnqueueTime><NextVisibleTime>1250700799348</NextVisibleTime><FirstDequeueTime>1250700779318</FirstDequeueTime><DequeueCount>1</DequeueCount><Priority>8</Priority></Message>";
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));

            XmlUnmarshallerContext context = new XmlUnmarshallerContext(stream, null);
            ReceiveMessageResponse response = (ReceiveMessageResponse)ReceiveMessageResponseUnmarshaller.Instance.Unmarshall(context);

            Message message = response.Message;
            Assert.IsTrue(message.Id == "5F290C926D472878-2-14D9529A8FA-200000001");
            Assert.IsTrue(message.ReceiptHandle == "1-ODU4OTkzNDU5My0xNDMyNzI3ODI3LTItOA==");
            Assert.IsTrue(message.BodyMD5 == "C5DD56A39F5F7BB8B3337C6D11B6D8C7");
            Assert.IsTrue(message.Body == "This is a test message");
            Assert.IsTrue(message.EnqueueTime == AliyunSDKUtils.ConvertFromUnixEpochSeconds(1250700979248));
            Assert.IsTrue(message.NextVisibleTime == AliyunSDKUtils.ConvertFromUnixEpochSeconds(1250700799348));
            Assert.IsTrue(message.FirstDequeueTime == AliyunSDKUtils.ConvertFromUnixEpochSeconds(1250700779318));
            Assert.IsTrue(message.DequeueCount == 1);
            Assert.IsTrue(message.Priority == 8);
        }
    }
}
