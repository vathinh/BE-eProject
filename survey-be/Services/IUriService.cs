using CodeFirstDemo.Filter;

namespace CodeFirstDemo.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
