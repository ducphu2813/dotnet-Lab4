namespace Application.DTO;

//dto tương ứng với class Book
public class BookResponse
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Title { get; set; }
    public bool Available { get; set; }
    public int? Cost { get; set; }
    public string? Publisher { get; set; }
    public string? Author { get; set; }
    public DateTime? CreateOn { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    
    //genre
    public GenreResponse Genre { get; set; }
}