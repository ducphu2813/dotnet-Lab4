namespace Domain.Entities;

public class BookCatalogue : BaseEntity
{
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    
    //khóa ngoại đến Catalogue
    public Guid CatalogueId { get; set; }
    public Catalogue Catalogue { get; set; }
    
    //khóa ngoại đến Book
    public Guid BookId { get; set; }
    public Book Book { get; set; }
}