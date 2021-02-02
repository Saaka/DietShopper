using DietShopper.Common.Models;

namespace DietShopper.Application.Repositories.Models
{
    public class GetSimpleProductsQueryDto : IPageableRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}