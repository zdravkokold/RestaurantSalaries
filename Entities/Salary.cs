using System.ComponentModel;
using RestaurantSalaries.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Salary
{
    public int Id { get; set; }

    [Column("СлужителId")]
    [DisplayName("СлужителID")]
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; }

    [Column("Име")]
    [DisplayName("Име")]
    public string Name { get; set; }

    [Column("Длъжност")]
    [DisplayName("Длъжност")]
    public string Position { get; set; }

    [Column("Почасова Ставка")]
    [DisplayName("Почасова Ставка")]
    public decimal HourlyRate { get; set; }

    [Column("Отработени Часове")]
    [DisplayName("Отработени Часове")]
    public int HoursWorked { get; set; }

    [Column("Бонус")]
    [DisplayName("Бонус")]
    public decimal Bonus { get; set; }

    [Column("Удръжки")]
    [DisplayName("Удръжки")]
    public decimal Deductions { get; set; }

    [Column("Основна Заплата")]
    [DisplayName("Основна Заплата")]
    public decimal BaseSalary { get; set; }

    [Column("Общо Заплата")]
    [DisplayName("Общо Заплата")]
    public decimal TotalSalary { get; set; }

    [Column("Заплата за месец")]
    [DisplayName("Заплата за месец")]
    public string SalaryMonth { get; set; }

    [Column("Изчислена на")]
    public DateTime SalaryDate { get; set; }
}