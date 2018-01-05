# NetCorePal.Aliyun.MNS
Aliyun.MNS for .net standrad with DI

## Install

To install NetCorePal.Aliyun.MNS from the Package Manager Console, run the following command:


		Install-Package NetCorePal.Aliyun.MNS.DependencyInjection

## How to use

#### How to register MNS client

		 services.AddMNS(option=> 
            {
                option.AccessKeyId = "<your access key id>";
                option.SecretAccessKey = "<your secret access key>";
                option.Endpoint = "<valid endpoint>";
            });


#### How to resolve MNS client

		using Aliyun.MNS;

		services.BuildServiceProvider().GetRequiredService<IMNS>();


