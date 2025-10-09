using Microsoft.Extensions.Configuration;

try
{
    var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // where to look for appsettings.json
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

    string connectionString = config.GetConnectionString("KITSProduct")
    ?? throw new ArgumentException("No connection string", nameof(connectionString));

    MainController mc = new MainController(connectionString);

    var ans = await mc.GetCatalogNodes(1479000001);

    Environment.ExitCode = (int)ExitCodes.Success;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
    Environment.ExitCode = (int)ExitCodes.InvalidArguments;
}

enum ExitCodes
{
    Success = 0,
    InvalidArguments = 1,
    NotFound = 2,
    UnexpectedError = 10
}