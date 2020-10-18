using System;

namespace DietShopper.Common.Requests.Models
{
    public class AuthorizedUser
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public bool IsAdmin { get; set; }
    }
}