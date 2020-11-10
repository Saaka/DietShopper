using System;
using System.Collections.Generic;

namespace DietShopper.Common.Models
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItemsCount { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
        public int MaxPage => (int)Math.Ceiling((decimal)TotalItemsCount / PageSize);

        public bool HasNextPage => PageNumber < MaxPage;
        public bool HasPrevPage => PageNumber > 1;
    }
}