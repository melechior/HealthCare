using System;
using System.Collections.Generic;

namespace HealthCare.Framework.Paging
{
    public class PagedQueryResult<TQueryView>
    {
        public PagedQueryResult()
        {
            Data = new List<TQueryView>();
        }
        public List<TQueryView> Data { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasMoreResults => TotalCount > (TotalPages * PageSize);
    }
}
