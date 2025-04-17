using RestaurantSalaries.Data;

namespace RestaurantSalaries.Forms
{
    public partial class LoginForm : Form
    {
        private readonly RestaurantSalariesDbContext context;
        private readonly RestaurantService restaurantService;        

        public LoginForm(RestaurantSalariesDbContext context)
        {
            InitializeComponent();
            this.context = context;
            this.restaurantService = new RestaurantService(context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Моля, въведете потребителско име и парола.";
                lblError.Visible = true;
                return;
            }

            var user = context.Users.FirstOrDefault(u => (u.UserName == usernameOrEmail || u.Email == usernameOrEmail));

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                lblError.Text = "Грешно потребителско име или парола.";
                lblError.Visible = true;
                return;
            }

            string adminRoleId = context.Roles.FirstOrDefault(r => r.Name == "Admin")?.Id;

            Session.CurrentUser = user;
            Session.UserRole = context.UserRoles.FirstOrDefault(ur => ur.UserId == user.Id && ur.RoleId == adminRoleId) != null ? "Admin" : "Employee";

            this.Hide();
            HomeForm homeForm = new HomeForm(restaurantService, context);
            homeForm.Show();
        }
    }
}