﻿using System.Data;
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
            employeesGridView.Columns["Id"].Visible = false;
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

            hrsWorkedToday.Visible = false;
            hrsTodayLabel.Visible = false;
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

            hrsWorkedToday.Visible = true;
            hrsTodayLabel.Visible = true;

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
                hrsWorkedToday.Visible = false;
                hrsTodayLabel.Visible = false;

                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            string currentMonthYear = DateTime.Now.ToString("MM-yyyy");

            if (selectedEmployee == null)
            {
                hrsWorkedToday.Visible = false;
                hrsTodayLabel.Visible = false;

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

                Salary salary = new Salary
                {
                    Employee = newEmployee,
                    EmployeeId = newEmployee.Id,
                    Name = newEmployee.Name,
                    Position = newEmployee.Position,
                    HourlyRate = newEmployee.HourlyRate,
                    HoursWorked = newEmployee.HoursWorked,
                    BaseSalary = newEmployee.HourlyRate * newEmployee.HoursWorked,
                    Bonus = newEmployee.Bonus,
                    Deductions = newEmployee.Deductions,
                    TotalSalary = newEmployee.Salary,
                    SalaryDate = DateTime.Now,
                    SalaryMonth = currentMonthYear
                };

                restaurantService.AddSalary(salary);
            }
            else
            {
                hrsWorkedToday.Visible = true;
                hrsTodayLabel.Visible = true;

                // Редактиране на съществуващ служител
                selectedEmployee.Name = nameTextBox.Text;
                selectedEmployee.Position = positionTextBox.Text;
                selectedEmployee.HourlyRate = decimal.Parse(hourlyRateTextBox.Text);
                selectedEmployee.HoursWorked = int.Parse(hoursWorkedTextBox.Text);

                if (hrsWorkedToday.Text != "")
                { 
                    selectedEmployee.HoursWorked += int.Parse(hrsWorkedToday.Text);
                    hrsWorkedToday.Text = "";
                }

                selectedEmployee.Bonus = decimal.Parse(bonusTextBox.Text);
                selectedEmployee.Deductions = decimal.Parse(deductionsTextBox.Text);

                selectedEmployee.Salary = restaurantService
                    .CalculateSalary(selectedEmployee.HoursWorked,
                                     selectedEmployee.HourlyRate,
                                     selectedEmployee.Bonus,
                                     selectedEmployee.Deductions);                         

                restaurantService.UpdateEmployee(selectedEmployee);

                // Проверка за съществуваща заплата за конкретния месец
                Salary? existingSalary = restaurantService.GetSalaryByEmployeeAndMonth(selectedEmployee.Id, currentMonthYear);

                if (existingSalary != null)
                {
                    existingSalary.Name = selectedEmployee.Name;
                    existingSalary.Position = selectedEmployee.Position;
                    existingSalary.HourlyRate = selectedEmployee.HourlyRate;
                    existingSalary.HoursWorked = selectedEmployee.HoursWorked;
                    existingSalary.BaseSalary = selectedEmployee.HourlyRate * selectedEmployee.HoursWorked;
                    existingSalary.Bonus = selectedEmployee.Bonus;
                    existingSalary.Deductions = selectedEmployee.Deductions;
                    existingSalary.TotalSalary = selectedEmployee.Salary;

                    restaurantService.UpdateSalary(existingSalary);
                }
                else
                {
                    Salary newSalary = new Salary
                    {
                        Employee = selectedEmployee,
                        EmployeeId = selectedEmployee.Id,
                        Name = selectedEmployee.Name,
                        Position = selectedEmployee.Position,
                        HourlyRate = selectedEmployee.HourlyRate,
                        HoursWorked = selectedEmployee.HoursWorked,
                        BaseSalary = selectedEmployee.HourlyRate * selectedEmployee.HoursWorked,
                        Bonus = selectedEmployee.Bonus,
                        Deductions = selectedEmployee.Deductions,
                        TotalSalary = selectedEmployee.Salary,
                        SalaryDate = DateTime.Now,
                        SalaryMonth = currentMonthYear
                    };
                    restaurantService.AddSalary(newSalary);
                }
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

                    List<DataGridViewColumn> visibleColumns = employeesGridView.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible).ToList();

                    foreach (var column in visibleColumns)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }

                    foreach (DataGridViewRow row in employeesGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        DataRow dr = dt.NewRow();
                        int colIndex = 0;

                        foreach (var column in visibleColumns)
                        {
                            dr[colIndex++] = row.Cells[column.Index].Value ?? string.Empty;
                        }

                        dt.Rows.Add(dr);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        IXLWorksheet ws = wb.Worksheets.Add(dt, "Employees");
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Експортирането бе успешно!");
                }
            }
        }
    }
}