namespace Domain.Entities;

public class Genre : BaseEntity
{
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    
    //quan hệ tới Book
    public ICollection<Book> Books { get; set; }
}