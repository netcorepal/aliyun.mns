using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class MNSOptions
    {
        public string AccessKeyId { set; get; }

        public string SecretAccessKey { set; get; }

        public string Endpoint { set; get; }
    }
}
