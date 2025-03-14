using System.Data;
using ClosedXML.Excel;
using RestaurantSalaries.Data;

namespace RestaurantSalaries.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly RestaurantService restaurantService;

        public ReportsForm(RestaurantService restaurantService)
        {
            InitializeComponent();
            this.restaurantService = restaurantService;
            LoadSalaries();
            CalculateTotalSalaryExpense();
        }

        private void LoadSalaries()
        {
            salariesGridView.DataSource = restaurantService.GetAllSalaries();

            salariesGridView.Columns["Id"].Visible = false;
            salariesGridView.Columns["EmployeeId"].Visible = false;
            salariesGridView.Columns["Employee"].Visible = false;
            salariesGridView.Columns["SalaryDate"].Visible = false;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            string filter = filterTextBox.Text.ToLower();

            List<Salary> filteredData = restaurantService.GetAllSalaries()
                .Where(emp => emp.EmployeeId.ToString().ToLower().Contains(filter)
                    || emp.Id.ToString().ToLower().Contains(filter)
                    || emp.Name.ToLower().Contains(filter)
                    || emp.Position.ToLower().Contains(filter)
                    || emp.HourlyRate.ToString().ToLower().Contains(filter)
                    || emp.HoursWorked.ToString().ToLower().Contains(filter)
                    || emp.Bonus.ToString().ToLower().Contains(filter)
                    || emp.Deductions.ToString().ToLower().Contains(filter)
                    || emp.BaseSalary.ToString().ToLower().Contains(filter)
                    || emp.TotalSalary.ToString().ToLower().Contains(filter))
                .ToList();

            salariesGridView.DataSource = filteredData;

            totalSalaryExpense.Text = filteredData.Sum(s => s.TotalSalary).ToString() + " лв.";
        }

        private void exportReportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable();

                    List<DataGridViewColumn> visibleColumns = salariesGridView.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible).ToList();

                    foreach (var column in visibleColumns)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }

                    foreach (DataGridViewRow row in salariesGridView.Rows)
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
                        IXLWorksheet ws =  wb.Worksheets.Add(dt, "Salaries");
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Експортирането бе успешно!");
                }
            }
        }

        private void filterByDateBtn_Click(object sender, EventArgs e)
        {
            string filter = filterTextBox.Text.ToLower();

            List<Salary> filteredData = restaurantService.GetAllSalaries()
                .Where(emp => startDate.Value <= emp.SalaryDate && endDate.Value >= emp.SalaryDate)
                .ToList();

            salariesGridView.DataSource = filteredData;

            totalSalaryExpense.Text = filteredData.Sum(s => s.TotalSalary).ToString() + " лв.";
        }

        private void CalculateTotalSalaryExpense()
        {
            totalSalaryExpense.Text = restaurantService.GetAllSalaries().Sum(s => s.TotalSalary).ToString() + " лв.";
        }
    }
}