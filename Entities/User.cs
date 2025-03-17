using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace RestaurantSalaries.Entities
{
    public class User : IdentityUser
    {
        [Column("Роля")]
        [DisplayName("Роля")]
        public string Role { get; set; }
    }
}