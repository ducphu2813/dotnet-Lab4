namespace Domain.Entities;

public class Catalogue : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    //quan hệ tới BookCatalogue
    public ICollection<BookCatalogue> BookCatalogues { get; set; }
}