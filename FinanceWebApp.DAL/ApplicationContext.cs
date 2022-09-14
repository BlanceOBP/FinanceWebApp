using FinanceWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceWebApp.DAL
{
    public class ApplicationContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ApplicationContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Source> sources { get; set; }
        public DbSet<Source_of_Income> sources_of_income { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Expense_category> expense_categories { get; set; }

        


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Username=postgres;Password=a200308;Database=FinanceWebApp");
        }*/
    }
}
