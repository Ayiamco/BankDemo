namespace BankDemo.Data.Models
{
    public class PagedRequest
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class PagedResponse<T>
    {
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; } = 50;
        public int TotalCount { get; private set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);

        public IEnumerable<T> PageItems { get; private set; }

        public PagedResponse(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageItems = items;
        }

        public static PagedResponse<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}
