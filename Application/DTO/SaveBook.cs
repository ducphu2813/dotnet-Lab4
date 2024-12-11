namespace Application.DTO;

public class SaveBook
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
    
    //id genre
    public Guid GenreId { get; set; }
}