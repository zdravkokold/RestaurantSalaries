using RestaurantSalaries.Data;

namespace RestaurantSalaries
{
    public partial class SalaryCalculationForm : Form
    {
        private readonly RestaurantService restaurantService;

        public SalaryCalculationForm(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
            InitializeComponent();
            FillEmployeeInfo();
        }

        private void SalaryCalculationForm_Load(object sender, EventArgs e)
        {
            if (employeesDropdown.Items.Count == 0)
            {
                employeesDropdown.Items.AddRange(restaurantService.GetAllEmployees().Select(e => e.Name).ToArray());
            }
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hoursWorkedTxt.Text) ||
                string.IsNullOrWhiteSpace(hourlyRateTxt.Text) ||
                string.IsNullOrWhiteSpace(bonusTxt.Text) ||
                string.IsNullOrWhiteSpace(deductionsTxt.Text ))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            int hoursWorked = int.Parse(hoursWorkedTxt.Text);
            decimal hourlyRate = decimal.Parse(hourlyRateTxt.Text);
            decimal bonus = decimal.Parse(bonusTxt.Text);
            decimal deductions = decimal.Parse(deductionsTxt.Text);

            decimal totalSalary = restaurantService.CalculateSalary(hoursWorked, hourlyRate, bonus, deductions);

            salaryTxt.Text = totalSalary.ToString();
        }

        private void FillEmployeeInfo()
        {
            string? userName = Session.CurrentUser.UserName;
            var employee = restaurantService.GetAllEmployees().FirstOrDefault(e => e.Name == userName);

            if (Session.UserRole == "Employee")
            {
                if (employee != null)
                {
                    employeesDropdown.Text = employee.Name;
                    hoursWorkedTxt.Text = employee.HoursWorked.ToString();
                    hourlyRateTxt.Text = employee.HourlyRate.ToString();
                    bonusTxt.Text = employee.Bonus.ToString();
                    deductionsTxt.Text = employee.Deductions.ToString();
                    salaryTxt.Text = employee.Salary.ToString();
                }
            }
        }
    }
}