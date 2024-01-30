using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}
