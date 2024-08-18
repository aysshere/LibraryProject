using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LibraryProjectDbContextFactory : IDesignTimeDbContextFactory<LibraryProjectDb>
    {
        public LibraryProjectDb CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options builder
            var optionsBuilder = new DbContextOptionsBuilder<LibraryProjectDb>();
            var connectionString = configuration.GetConnectionString("ConnStr");

            // Use the connection string to configure the context
            optionsBuilder.UseSqlServer(connectionString);

            // Return the context
            return new LibraryProjectDb(optionsBuilder.Options);
        }
    }
}
