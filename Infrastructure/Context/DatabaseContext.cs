using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DatabaseContext : DbContext
{
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    //khởi tạo các dbset tương ứng với các bảng trong database
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookImages> BookImages { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    public DbSet<BookCatalogue> BookCatalogues { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Catalogue> Catalogues { get; set; }

    //thiết lập mối quan hệ gi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //quan hệ giữa Cart và CartDetail
        //1 cart có nhiều cart detail
        //1 cart detail chỉ thuộc về 1 cart
        modelBuilder.Entity<Cart>()
            .HasMany(c => c.CartDetails)
            .WithOne(cd => cd.Cart)
            .HasForeignKey(cd => cd.CartId);
        
        //quan hệ giữa Book và CartDetail
        //1 book có nhiều cart detail
        //1 cart detail chỉ thuộc về 1 book
        modelBuilder.Entity<Book>()
            .HasMany(b => b.CartDetails)
            .WithOne(cd => cd.Book)
            .HasForeignKey(cd => cd.BookId);
        
        //quan hệ giữa Book và BookImages
        //1 book có nhiều book images
        //1 book image chỉ thuộc về 1 book
        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookImages)
            .WithOne(bi => bi.Book)
            .HasForeignKey(bi => bi.BookId);
        
        //quan hệ giữa Book và BookCatalogue
        //1 book có nhiều book catalogue
        //1 book catalogue chỉ thuộc về 1 book
        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookCatalogues)
            .WithOne(bc => bc.Book)
            .HasForeignKey(bc => bc.BookId);
        
        //quan hệ giữa Catalogue và BookCatalogue
        //1 catalogue có nhiều book catalogue
        //1 book catalogue chỉ thuộc về 1 catalogue
        modelBuilder.Entity<Catalogue>()
            .HasMany(c => c.BookCatalogues)
            .WithOne(bc => bc.Catalogue)
            .HasForeignKey(bc => bc.CatalogueId);
        
        //quan hệ giữa Genre và Book
        //1 genre có nhiều book
        //1 book chỉ có 1 genre
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId);
    }
}