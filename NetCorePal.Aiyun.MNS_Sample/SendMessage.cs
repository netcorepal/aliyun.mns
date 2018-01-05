using Aliyun.MNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCorePal.Aiyun.MNS_Sample
{
    public class SendMessage
    {
        static void Main(string[] args)
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"E:\MNS.json"));

            IMNS client = new Aliyun.MNS.MNSClient(config.AccessKeyId, config.AccessKey, config.EndPoint, null);

            client.CreateQueueAsync("testQueue").ContinueWith( async task=>
            {
                Stopwatch stopWatch = new Stopwatch();
                int index = 1;
                stopWatch.Start();
                while (index<=10)
                {
                    task.Result.SendMessageAsync($"Hello Message {index}");

                    index++;
                }
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                       ts.Hours, ts.Minutes, ts.Seconds,
                                                       ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
                Console.WriteLine("跑完消息");

                await client.DeleteQueueAsync("testQueue");
            });



            Console.ReadKey();
        }
    }
}
