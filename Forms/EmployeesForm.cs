using System.Data;
using ClosedXML.Excel;
using RestaurantSalaries.Data;
using RestaurantSalaries.Entities;

namespace RestaurantSalaries.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly RestaurantService restaurantService;
        private Employee selectedEmployee;

        public EmployeesForm(RestaurantService restaurantService)
        {
            InitializeComponent();
            this.restaurantService = restaurantService;
            LoadEmployees();
            formPanel.Visible = false;
        }

        private void LoadEmployees()
        {
            employeesGridView.DataSource = restaurantService.GetAllEmployees();
            employeesGridView.Columns["Id"].Width = 40;
            //employeesGridView.Columns["Salaries"].Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            selectedEmployee = null;
            nameTextBox.Text = "";
            positionTextBox.Text = "";
            hourlyRateTextBox.Text = "";
            hoursWorkedTextBox.Text = "";
            bonusTextBox.Text = "";
            deductionsTextBox.Text = "";
            formPanel.Visible = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (employeesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Моля, изберете служител за редактиране.");
                return;
            }

            int employeeId = (int)employeesGridView.SelectedRows[0].Cells["Id"].Value;
            selectedEmployee = restaurantService.GetEmployeeById(employeeId);

            nameTextBox.Text = selectedEmployee.Name;
            positionTextBox.Text = selectedEmployee.Position;
            hourlyRateTextBox.Text = selectedEmployee.HourlyRate.ToString();
            hoursWorkedTextBox.Text = selectedEmployee.HoursWorked.ToString();
            bonusTextBox.Text = selectedEmployee.Bonus.ToString();
            deductionsTextBox.Text = selectedEmployee.Deductions.ToString();
            formPanel.Visible = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (employeesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Моля, изберете служител за изтриване.");
                return;
            }

            int employeeId = (int)employeesGridView.SelectedRows[0].Cells["Id"].Value;
            var result = MessageBox.Show("Сигурни ли сте, че искате да изтриете този служител?", "Потвърждение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                restaurantService.DeleteEmployee(employeeId);
                LoadEmployees();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(hourlyRateTextBox.Text) ||
                string.IsNullOrWhiteSpace(hoursWorkedTextBox.Text) ||
                string.IsNullOrWhiteSpace(bonusTextBox.Text) ||
                string.IsNullOrWhiteSpace(deductionsTextBox.Text) ||
                string.IsNullOrWhiteSpace(positionTextBox.Text))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            if (selectedEmployee == null)
            {
                // Добавяне на нов служител
                Employee newEmployee = new Employee
                {
                    Name = nameTextBox.Text,
                    Position = positionTextBox.Text,
                    HourlyRate = decimal.Parse(hourlyRateTextBox.Text),
                    HoursWorked = int.Parse(hoursWorkedTextBox.Text),
                    Bonus = decimal.Parse(bonusTextBox.Text),
                    Deductions = decimal.Parse(deductionsTextBox.Text),
                    Salary = restaurantService
                        .CalculateSalary(int.Parse(hoursWorkedTextBox.Text),
                                         decimal.Parse(hourlyRateTextBox.Text),
                                         decimal.Parse(bonusTextBox.Text),
                                         decimal.Parse(deductionsTextBox.Text))
                };

                restaurantService.AddEmployee(newEmployee);

                Salary salary = new Salary // Добавяне на заплата за новия служител
                {
                    Employee = newEmployee,
                    EmployeeId = newEmployee.Id,
                    HourlyRate = newEmployee.HourlyRate,
                    HoursWorked = newEmployee.HoursWorked,
                    BaseSalary = newEmployee.HourlyRate * newEmployee.HoursWorked,
                    Bonus = newEmployee.Bonus,
                    Deductions = newEmployee.Deductions,
                    TotalSalary = newEmployee.Salary,
                    DateSalaryRecieved = DateTime.Now
                };
                restaurantService.AddSalary(salary);
            }
            else
            {
                // Редактиране на съществуващ служител
                selectedEmployee.Name = nameTextBox.Text;
                selectedEmployee.Position = positionTextBox.Text;
                selectedEmployee.HourlyRate = decimal.Parse(hourlyRateTextBox.Text);
                selectedEmployee.HoursWorked = int.Parse(hoursWorkedTextBox.Text);
                selectedEmployee.Bonus = decimal.Parse(bonusTextBox.Text);
                selectedEmployee.Deductions = decimal.Parse(deductionsTextBox.Text);
                selectedEmployee.Salary = restaurantService
                    .CalculateSalary(int.Parse(hoursWorkedTextBox.Text),
                                     decimal.Parse(hourlyRateTextBox.Text),
                                     decimal.Parse(bonusTextBox.Text),
                                     decimal.Parse(deductionsTextBox.Text));

                restaurantService.UpdateEmployee(selectedEmployee);

                Salary salary = new Salary // Добавяне на редактирана заплата за редактирания служител
                {
                    Employee = selectedEmployee,
                    EmployeeId = selectedEmployee.Id,
                    HourlyRate = selectedEmployee.HourlyRate,
                    HoursWorked = selectedEmployee.HoursWorked,
                    BaseSalary = selectedEmployee.HourlyRate * selectedEmployee.HoursWorked,
                    Bonus = selectedEmployee.Bonus,
                    Deductions = selectedEmployee.Deductions,
                    TotalSalary = selectedEmployee.Salary,
                    DateSalaryRecieved = DateTime.Now
                };
                restaurantService.AddSalary(salary);
            }

            formPanel.Visible = false;
            LoadEmployees();
        }

        private void filterButton_Click(object sender, EventArgs e) // Филтриране на данни по име или позиция
        {
            string filter = filterTextBox.Text.ToLower();

            List<Employee> filteredData = restaurantService.GetAllEmployees()
                .Where(emp => emp.Name.ToLower().Contains(filter) || emp.Position.ToLower().Contains(filter))
                .ToList();

            employeesGridView.DataSource = filteredData;
        }

        private void exportButton_Click(object sender, EventArgs e) // Експорт на данни в Excel
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn column in employeesGridView.Columns)
                    {
                        if (column.Visible)
                            dt.Columns.Add(column.HeaderText);
                    }

                    foreach (DataGridViewRow row in employeesGridView.Rows)
                    {
                        if (row.IsNewRow) continue;
                        DataRow dr = dt.NewRow();

                        for (int i = 0; i < employeesGridView.Columns.Count; i++)
                        {
                            if (employeesGridView.Columns[i].Visible)
                            { 
                                dr[i] = row.Cells[i].Value ?? string.Empty;                            
                            }
                        }

                        dt.Rows.Add(dr);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Employees");
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Експортирането бе успешно!");
                }
            }
        }
    }
}