using System;
using System.Collections.Generic;
using System.Linq;

namespace DietShopper.Common.Models
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            Items = items.ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
            TotalPages = (int) Math.Ceiling((decimal) TotalItemsCount / PageSize);
            HasNextPage = PageNumber < TotalPages;
            HasPreviousPage = PageNumber > 1;
        }

        public IReadOnlyCollection<T> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalItemsCount { get; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
    }
}