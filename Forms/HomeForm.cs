﻿using RestaurantSalaries.Data;

namespace RestaurantSalaries.Forms
{
    public partial class HomeForm : Form
    {
        private readonly RestaurantService restaurantService;
        private readonly RestaurantSalariesDbContext context;

        public HomeForm(RestaurantService restaurantService, RestaurantSalariesDbContext context)
        {
            InitializeComponent();
            this.restaurantService = restaurantService;
            this.context = context;
            ShowHomeScreen();
            HideAdminButtonsIfRoleIsNotAdmin();
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

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ReportsForm(restaurantService));
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
                Text = @"


Добре дошли в системата!

Нашето приложение улеснява управлението на вашия ресторант, като предлага:

✅ Управление на служители – добавяне, редактиране и изтриване
✅ Изчисляване на заплати – автоматично на база отработени часове и ставки
✅ Справки и отчети – анализ на разходите и възнагражденията
✅ Търсене и филтриране – бърз достъп до нужната информация",

                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Dock = DockStyle.Top
            };
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Controls.Add(pictureBox2);
        }

        private void regiterEmployeesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(context, restaurantService);
            registerForm.Show();
        }

        private void HideAdminButtonsIfRoleIsNotAdmin()
        {
            if (Session.UserRole != "Admin")
            {
                employeesBtn.Visible = false;
                regiterEmployeesBtn.Visible = false;
                reportsBtn.Visible = false;
            }
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(context);
            loginForm.Show();

            this.Close();
        }
    }
}
