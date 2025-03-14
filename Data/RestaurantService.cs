using Microsoft.EntityFrameworkCore;
using RestaurantSalaries.Entities;

namespace RestaurantSalaries.Data
{
    public class RestaurantService
    {
        private readonly RestaurantSalariesDbContext context;

        public RestaurantService(RestaurantSalariesDbContext context)
        {
            this.context = context;
        }

        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public List<Employee> GetAllEmployees() => context.Employees.ToList();

        public Employee GetEmployeeById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

        public void AddSalary(Salary salary)
        {
            context.Salaries.Add(salary);
            context.SaveChanges();
        }

        public List<Salary> GetAllSalaries() => context.Salaries.Include(s => s.Employee).ToList();

        public void UpdateSalary(Salary salary)
        {
            context.Salaries.Update(salary);
            context.SaveChanges();
        }

        public decimal CalculateSalary(int hoursWorked, decimal hourlyRate, decimal bonus, decimal deductions)
        {            
            decimal baseSalary = hourlyRate * hoursWorked;
            decimal totalSalary = baseSalary + bonus - deductions;
                        
            return totalSalary;
        }

        public Salary? GetSalaryByEmployeeAndMonth(int id, string currentMonthYear)
        {
            return context.Salaries.Include(s => s.Employee)
                .Where(e => e.Employee.Id == id && e.SalaryMonth == currentMonthYear)
                .ToList()
                .FirstOrDefault();
        }
    }
}