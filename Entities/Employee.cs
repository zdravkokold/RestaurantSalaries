using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSalaries.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Column("Име")]
        public string Name { get; set; }

        [Column("Длъжност")]
        public string Position { get; set; }
    }
}