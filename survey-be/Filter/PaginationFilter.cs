namespace CodeFirstDemo.Filter
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
            this.OrderBy = "";
            this.Search = "";
        }
        public PaginationFilter(int pageNumber, int pageSize, string orderBy = null, string search = null)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.OrderBy = orderBy;
            this.Search = search;
        }
    }
}
