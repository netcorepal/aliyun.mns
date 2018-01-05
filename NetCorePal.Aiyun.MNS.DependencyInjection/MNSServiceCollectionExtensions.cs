using Aliyun.MNS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MNSServiceCollectionExtensions
    {
        public static IServiceCollection AddMNS(this IServiceCollection services, Action<MNSOptions> configure)
        {
            MNSOptions mnsOptions = new MNSOptions();
            configure(mnsOptions);

            if (string.IsNullOrEmpty(mnsOptions.AccessKeyId))
            {
                throw new ArgumentNullException(nameof(mnsOptions.AccessKeyId));
            }

            if (string.IsNullOrEmpty(mnsOptions.SecretAccessKey))
            {
                throw new ArgumentNullException(nameof(mnsOptions.SecretAccessKey));
            }

            if (string.IsNullOrEmpty(mnsOptions.Endpoint))
            {
                throw new ArgumentNullException(nameof(mnsOptions.Endpoint));
            }

            string regex = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
            if (!Regex.IsMatch(mnsOptions.Endpoint, regex))
            {
                throw new ArgumentException($"Invalid endpoint address '{mnsOptions.Endpoint}'", nameof(mnsOptions.Endpoint));
            }

            IMNS client = new MNSClient(mnsOptions.AccessKeyId, mnsOptions.SecretAccessKey, mnsOptions.Endpoint);
            services.AddSingleton<IMNS>(client);

            return services;
        }

    }
}
