using System;
using System.Collections.Generic;
using System.Linq;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Common.Models
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            Validate(items, pageNumber, pageSize, totalItemsCount);
            Items = items?.ToList() ?? new List<T>();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
            TotalPages = (int) Math.Ceiling((decimal) TotalItemsCount / PageSize);
            HasNextPage = PageNumber < TotalPages;
            HasPreviousPage = PageNumber > 1;
        }

        private void Validate(IEnumerable<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            if (pageNumber < 1)
                throw new InternalException(ErrorCode.InvalidRequestPageNumber);
            if (pageSize < 1)
                throw new InternalException(ErrorCode.InvalidRequestPageSize);
            if (totalItemsCount < 0 || totalItemsCount < items.Count())
                throw new InternalException(ErrorCode.InvalidPagedListTotalItemsCount);
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