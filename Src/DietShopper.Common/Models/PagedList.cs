using System;
using System.Collections.Generic;
using System.Linq;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Common.Models
{
    public class PagedList<T>
    {
        public PagedList(IList<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            Validate(items, pageNumber, pageSize, totalItemsCount);
            Items = items?.ToList() ?? new List<T>();
            Options = new PaginationOptions(pageNumber, pageSize, totalItemsCount);
        }

        private void Validate(IList<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            if (pageNumber < 1)
                throw new InternalException(ErrorCode.InvalidRequestPageNumber);
            if (pageSize < 1)
                throw new InternalException(ErrorCode.InvalidRequestPageSize);
            if (totalItemsCount < 0 || totalItemsCount < items.Count())
                throw new InternalException(ErrorCode.InvalidPagedListTotalItemsCount);
        }

        public IReadOnlyCollection<T> Items { get; }
        public PaginationOptions Options { get; }
    }
}