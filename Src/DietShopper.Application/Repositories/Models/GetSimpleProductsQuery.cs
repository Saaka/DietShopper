using DietShopper.Common.Models;

namespace DietShopper.Application.Repositories.Models
{
    public class GetSimpleProductsQuery : IPageableRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}