var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Console.WriteLine("���� ������ �������:");
Console.WriteLine(config.GetConnectionString("DefaultConnection"));