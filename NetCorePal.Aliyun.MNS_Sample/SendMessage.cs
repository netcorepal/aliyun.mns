using Aliyun.MNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCorePal.Aliyun.MNS_Sample
{
    public class SendMessage
    {
        static void Main(string[] args)
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));

            IMNS client = new MNSClient(config.AccessKeyId, config.AccessKey, config.EndPoint, null);
            //var index = 1;
            //while (index<=100)
            //{
            //    var queue=client.CreateQueueAsync("testQueue").Result;
            //    queue.SendMessageAsync($"Hello Message").Wait();
            //    client.DeleteQueueAsync("testQueue").Wait();
            //    index++;
            //}
            //client.CreateQueueAsync("testQueue").ContinueWith( async task=>
            //{

            //    await task.Result.SendMessageAsync($"Hello Message");
            //    //Stopwatch stopWatch = new Stopwatch();
            //    //int index = 1;
            //    //stopWatch.Start();
            //    //while (index<=10)
            //    //{
            //    //    task.Result.SendMessageAsync($"Hello Message {index}");

            //    //    index++;
            //    //}
            //    //stopWatch.Stop();
            //    //TimeSpan ts = stopWatch.Elapsed;
            //    //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    //                                       ts.Hours, ts.Minutes, ts.Seconds,
            //    //                                       ts.Milliseconds / 10);
            //    //Console.WriteLine("RunTime " + elapsedTime);
            //    //Console.WriteLine("跑完消息");

            //    await client.DeleteQueueAsync("testQueue");

            //    await client.CreateQueueAsync("testQueue");
            //});


            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
}
