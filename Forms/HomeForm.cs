using RestaurantSalaries.Data;

namespace RestaurantSalaries.Forms
{
    public partial class HomeForm : Form
    {
        private readonly RestaurantService restaurantService;

        public HomeForm(RestaurantService restaurantService)
        {
            InitializeComponent();
            this.restaurantService = restaurantService;
            ShowHomeScreen();
        }

        private void ShowFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();  
            form.TopLevel = false;  
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;  
            mainPanel.Controls.Add(form);
            form.Show();
            returnButton.Visible = true;
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new EmployeesForm(restaurantService));
        }

        private void calculatorBtn_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new SalaryCalculationForm(restaurantService));
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            ShowHomeScreen();
        }

        private void ShowHomeScreen()
        {
            mainPanel.Controls.Clear();
            returnButton.Visible = false; 
            Label welcomeLabel = new Label
            {
                Text = "Добре дошли в системата!",
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(welcomeLabel);
        }
    }
}
