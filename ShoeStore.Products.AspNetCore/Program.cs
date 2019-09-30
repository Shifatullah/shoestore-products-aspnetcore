using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Logging;

namespace ShoeStore.Products.AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();
                    config.AddAzureKeyVault(
                                        $"https://{builtConfig["KeyVault:Vault"]}.vault.azure.net/"
                                        );
                })
                .UseStartup<Startup>()
                .Build();
    }
}
