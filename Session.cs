using RestaurantSalaries.Entities;

namespace RestaurantSalaries
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
        public static string UserRole { get; set; }
    }
}