using System;

namespace DietShopper.Persistence.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}