using Microsoft.EntityFrameworkCore;

namespace EnityFramework
{
    public class ProdcutDbContext : DbContext{
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
            DbContextOptionsBuilder dbContextOptionsBuilder = optionsBuilder.UseSqlServer(connectionString);
        }
    }
}