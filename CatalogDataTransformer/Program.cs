using System.Text.Json;
using Microsoft.Extensions.Configuration;

try
{

    var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

    string connectionString = config.GetConnectionString("KITSProduct")
    ?? throw new ArgumentException("No connection string", nameof(connectionString));

    var relativePath = config["DataCacheLocation"];

    if (string.IsNullOrWhiteSpace(relativePath))
    {
        throw new InvalidOperationException("Configuration 'DataCacheLocation' is missing or empty.");
    }

    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    MainController mc = new MainController(connectionString);
    var ans = await mc.GetCatalogProducts(186000001);

    string fileName = "CatalogProducts_186000001.json";
    string filePath = Path.Combine(relativePath, fileName);

    string jsonString = JsonSerializer.Serialize(ans, options);
    await File.WriteAllTextAsync(filePath, jsonString);

    Console.WriteLine($"Data successfully written to: {filePath}");

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