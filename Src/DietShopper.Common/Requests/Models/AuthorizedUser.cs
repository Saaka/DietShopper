namespace DietShopper.Common.Requests.Models
{
    public class AuthorizedUser
    {
        public int Userid { get; set; }
        public int UserGuid { get; set; }
        public int Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}