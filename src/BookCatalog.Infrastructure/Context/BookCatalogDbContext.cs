using BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure.Context
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions option):base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc=> new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc=>bc.CategoryId);

            modelBuilder.Seed();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
    }
}
