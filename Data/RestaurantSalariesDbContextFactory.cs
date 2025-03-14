using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantSalaries.Data
{
    public class RestaurantSalariesDbContextFactory : IDesignTimeDbContextFactory<RestaurantSalariesDbContext>
    {
        public RestaurantSalariesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantSalariesDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"); // Change conection string here during SetUp
                            // Change only here {----------------------};

            return new RestaurantSalariesDbContext(optionsBuilder.Options);
        }
    }
}
