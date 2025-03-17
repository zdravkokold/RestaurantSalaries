using RestaurantSalaries.Data;
using RestaurantSalaries.Forms;
using RestaurantSalaries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantSalaries
{
    internal static class Program
    {
        public static UserManager<User> UserManager;
        public static SignInManager<User> SignInManager;
        public static RoleManager<IdentityRole> RoleManager;

        [STAThread]
        static void Main() // The starting point of the application
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<RestaurantSalariesDbContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;")); // Change conection strig here during SetUp

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<RestaurantSalariesDbContext>()
                .AddDefaultTokenProviders();

            services.AddLogging();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            RestaurantSalariesDbContext dbContext = serviceProvider.GetRequiredService<RestaurantSalariesDbContext>();

            UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            SignInManager = serviceProvider.GetRequiredService<SignInManager<User>>();
            RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            EnsureRolesExistAsync().GetAwaiter().GetResult();
            SeedAdminUser(dbContext).GetAwaiter().GetResult();

            Application.Run(new LoginForm(dbContext));
        }

        private static async Task EnsureRolesExistAsync() // Creating Roles
        {
            if (!await RoleManager.RoleExistsAsync("Admin"))
            {
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await RoleManager.RoleExistsAsync("Employee"))
            {
                await RoleManager.CreateAsync(new IdentityRole("Employee"));
            }
        }

        private static async Task SeedAdminUser(RestaurantSalariesDbContext context) // Creating Admin User
        {
            string adminUserName = "admin";
            string adminEmail = "admin@gmail.com";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("123456");

            User? adminUser = context.Users.FirstOrDefault(u => (u.UserName == adminUserName && u.Email == adminEmail));

            if (adminUser == null)
            {
                User user = new User
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    Role = "Admin",
                    PasswordHash = hashedPassword
                };

                context.Users.Add(user);
                context.SaveChanges();

                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}