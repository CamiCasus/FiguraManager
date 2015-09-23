using System.Collections.Generic;

namespace Domain.Core.Pagination
{
    public class PaginationResult<T> where T : class
    {
        public int Count { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}
