using RestaurantSalaries.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantSalaries.Forms;

namespace RestaurantSalaries
{
    internal static class Program
    {        
        [STAThread] // The main entry point for the Application.
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            services.AddDbContext<RestaurantSalariesDbContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;"));

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<RestaurantSalariesDbContext>();

            ApplicationConfiguration.Initialize();
            var restaurantService = new RestaurantService(dbContext);
            Application.Run(new HomeForm(restaurantService));
        }
    }
}