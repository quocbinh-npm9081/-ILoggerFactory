
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
#nullable disable

namespace enityframework.Models
{
    public class ProductDbContext : DbContext{
        public readonly ILoggerFactory  loggerFactory = LoggerFactory.Create(builder => {
            //LogLevel.Information Lhien thi nhieu thong tin hon,  LogLevel.Error chi hien thi thong tin khi gap loi~
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);.// hien thi hoat dong database
            builder.AddConsole();
        });

        public DbSet<Product> products {set; get;}
        private const string connectionString = @"
            Data Source=localhost,1433;
            Initial Catalog=data01;
            User ID =SA;
            Password=Password123;
            TrustServerCertificate=True

        ";
        //OnConfiguring menthod run when DBContext is initialized
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory); // logger trong C# giong mogran ko Nodejs
            optionsBuilder.UseSqlServer(connectionString); 
        }
    }
}