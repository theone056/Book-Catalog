using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Models
{
    public class PagingRequestModel
    {
        const int maxSizePage = 50;
        public int PageNumber { get; set; }
        private int pageSize;

        public int PageSize {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > maxSizePage ? maxSizePage : value;
            }
        }

        public string orderBy { get; set; } = "Id";
        public string direction { get; set; } = "asc";
    }
}
