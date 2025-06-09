var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Console.WriteLine("Тест чтения конфига:");
Console.WriteLine(config.GetConnectionString("DefaultConnection"));