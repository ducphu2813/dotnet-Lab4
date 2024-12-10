namespace Domain.Entities;

public class Book : BaseEntity
{
    public string? Code { get; set; }
    public string? Title { get; set; }
    public bool Available { get; set; }
    public int? Cost { get; set; }
    public string? Publisher { get; set; }
    public string? Author { get; set; }
    public DateTime? CreateOn { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    
    //định nghĩa các khóa ngoại đến genre
    public Guid GenreId { get; set; }
    public Genre Genre { get; set; }
    
    //quan hệ tới BookImages
    public ICollection<BookImages> BookImages { get; set; }
    
    //quan hệ tới CartDetail
    public ICollection<CartDetail> CartDetails { get; set; }
    
    //quan hệ tới BookCatalogue
    public ICollection<BookCatalogue> BookCatalogues { get; set; }
}