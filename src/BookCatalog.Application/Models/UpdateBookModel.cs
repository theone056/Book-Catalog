using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Models
{
    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        [NotMapped]
        public List<int> SelectedCategories { get; set; }
    }
}
