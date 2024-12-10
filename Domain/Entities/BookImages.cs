namespace Domain.Entities;

public class BookImages : BaseEntity
{
    public string? Name { get; set; }

    //khóa ngoại đến Book
    public Guid BookId { get; set; }
    public Book Book { get; set; }
}