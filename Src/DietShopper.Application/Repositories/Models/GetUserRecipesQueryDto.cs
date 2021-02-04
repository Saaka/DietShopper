using DietShopper.Common.Models;

namespace DietShopper.Application.Repositories.Models
{
    public class GetUserRecipesQueryDto : IPageableRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int UserId { get; set; }
    }
}