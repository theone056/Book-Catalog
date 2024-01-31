using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Models
{
    public class PagingResponseModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public List<BookModelResult> Books { get; set; }
    }
}
