namespace HealthCare.Framework.Paging
{
    public class PagedQuery
    {
        private int pageIndex;
        private int pageSize;

        public int PageIndex
        {
            get
            {
                return pageIndex <= 0 ? 1 : pageIndex;
            }
            set { pageIndex = value; }
        }
        public int PageSize
        {
            get
            {
                return pageSize <= 0 ? 10 : pageSize;
            }
            set { pageSize = value; }
        }
    }
}
