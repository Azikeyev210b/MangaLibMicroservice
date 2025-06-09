using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MangaLibDbContext>
    {
        public MangaLibDbContext CreateDbContext(string[] args)
        {
            try
            {
                var basePath = Directory.GetCurrentDirectory();
                var solutionRoot = Path.GetFullPath(Path.Combine(basePath, "../../"));
                var appSettingsPath = Path.Combine(solutionRoot, "Presentation", "MangaLib.WebHost", "appsettings.json");

                Console.WriteLine($"Пытаемся прочитать конфиг из: {appSettingsPath}");

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(solutionRoot)
                    .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true)
                    .Build();

                // Проверяем все connection strings для диагностики
                Console.WriteLine("Найдены строки подключения:");
                foreach (var cs in configuration.GetSection("ConnectionStrings").GetChildren())
                {
                    Console.WriteLine($"{cs.Key}: {cs.Value}");
                }

                var connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new Exception("Ключ 'MangaDatabase' не найден в ConnectionStrings");

                Console.WriteLine($"Используем строку: {connectionString}");

                var optionsBuilder = new DbContextOptionsBuilder<MangaLibDbContext>();
                optionsBuilder.UseNpgsql(connectionString);

                return new MangaLibDbContext(optionsBuilder.Options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
                throw;
            }
        }
    }
}