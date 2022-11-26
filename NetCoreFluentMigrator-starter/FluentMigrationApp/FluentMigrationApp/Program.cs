using FluentMigrationApp.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;

namespace FluentMigrationApp
{
    class Program
    {

        //Böylece.Net Console Application'da Dependency Injection'dan faydalanmış olacağız.İlk olarak framework servislerini Microsoft.Extensions.DependencyInjection altında olan ServiceCollection 'a ekliyoruz. Biz burada Fluent Migration kullanacağımız için  AddFluentMigratorCore() 'u ekliyoruz.Konfigurasyonu da bu aşamada yapabiliriz. Connection string'i MySQL mi SQL mi kullanacağımızı, Migration Sınıfmızı bu aşamada belirtiyoruz. Program.cs'nin Main metodunun son hali aşağıdaki gibi olmalı.

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var services = new ServiceCollection()
            .AddFluentMigratorCore()
             // Configure the runner
            .ConfigureRunner(
            builder => builder
            // Use SQL
            .AddSqlServer2012()
            // The SQL connection string
            .WithGlobalConnectionString("Server=.;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true")
            // Specify the assembly with the migrations
            .WithMigrationsIn(typeof(InitialMigration).Assembly))
            .BuildServiceProvider();


            // add StructureMap
            var container = new Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                    _.AssemblyContainingType<IMigrationRunnerBuilder>();
                });

            });

            try
            {
                using (var scope = services.CreateScope())
                {
                    // Instantiate the runner
                    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                    // Execute the migrations
                    runner.MigrateUp();
                    //runner.MigrateDown(202101261447);
                    //Execute the down scripts
                    //runner.RollbackToVersion(0);

                    Console.WriteLine("Migration has successfully executed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
