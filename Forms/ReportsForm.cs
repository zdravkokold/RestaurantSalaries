using ClosedXML.Excel;
using RestaurantSalaries.Data;
using RestaurantSalaries.Entities;
using System.Data;

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
        }

        private void LoadSalaries()
        {
            salariesGridView.DataSource = restaurantService.GetAllSalaries();
            salariesGridView.Columns["Id"].Width = 40;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            string filter = filterTextBox.Text.ToLower();

            List<Salary> filteredData = restaurantService.GetAllSalaries()
                .Where(emp => emp.EmployeeId.ToString().ToLower().Contains(filter)
                    || emp.HourlyRate.ToString().ToLower().Contains(filter)
                    || emp.HoursWorked.ToString().ToLower().Contains(filter)
                    || emp.Bonus.ToString().ToLower().Contains(filter)
                    || emp.Deductions.ToString().ToLower().Contains(filter)
                    || emp.BaseSalary.ToString().ToLower().Contains(filter)
                    || emp.TotalSalary.ToString().ToLower().Contains(filter)
                    || (startDate.Value <= emp.DateSalaryRecieved && endDate.Value >= emp.DateSalaryRecieved))
                .ToList();

            salariesGridView.DataSource = filteredData;
        }

        private void exportReportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn column in salariesGridView.Columns)
                    {
                        if (column.Visible)
                            dt.Columns.Add(column.HeaderText);
                    }

                    foreach (DataGridViewRow row in salariesGridView.Rows)
                    {
                        if (row.IsNewRow) continue;
                        DataRow dr = dt.NewRow();

                        for (int i = 0; i < salariesGridView.Columns.Count; i++)
                        {
                            if (salariesGridView.Columns[i].Visible)
                            {
                                dr[i] = row.Cells[i].Value ?? string.Empty;
                            }
                        }

                        dt.Rows.Add(dr);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Sa");
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Експортирането бе успешно!");
                }
            }
        }
    }
}
