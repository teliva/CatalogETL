using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Catalog Data Transformer Initialized.");

var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // where to look for appsettings.json
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

var connectionString = config.GetConnectionString("KITSProduct");

if (connectionString.IsNullOrEmpty())
{
    Console.WriteLine("No connection string provided");
}

MainController mc = new MainController(connectionString);
await mc.Fetcher(1479000001);