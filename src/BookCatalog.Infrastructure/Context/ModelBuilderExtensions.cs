using BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Fantasy"
            });

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 2,
                Name = "Science Fiction"
            });

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 3,
                Name = "Romance"
            });

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 4,
                Name = "Horror"
            });

            //for(int bookid = 2; bookid <= 1000; bookid++)
            //{
            //    var book = new Book()
            //    {
            //        Id = bookid,
            //        Title = "Test Title " + bookid,
            //        Description = "Test Description "+ bookid,
            //        PublishDate = DateTime.Now,
            //    };

            //    modelBuilder.Entity<Book>().HasData(book);

            //    for(int categoryId=1; categoryId <= 4; categoryId++)
            //    {
            //        modelBuilder.Entity<BookCategory>().HasData(new BookCategory()
            //        {
            //            BookId = book.Id,
            //            CategoryId = categoryId
            //        });
            //    }
            //}
        }
    }
}
