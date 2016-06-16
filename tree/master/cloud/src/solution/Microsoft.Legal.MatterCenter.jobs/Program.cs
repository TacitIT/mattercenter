﻿using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
namespace Microsoft.Legal.MatterCenter.Jobs
{
    public class Program
    {     
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var azureStorageConnectionString = configuration["Data:DefaultConnection:AzureStorageConnectionString"];
            JobHostConfiguration config = new JobHostConfiguration(azureStorageConnectionString);
            config.UseTimers();
            var host = new JobHost(config);            
            host.RunAndBlock();
        }
    }
}