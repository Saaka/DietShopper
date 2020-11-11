namespace DietShopper.Common.Models
{
    public interface IPageableRequest
    {
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}