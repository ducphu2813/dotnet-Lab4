namespace Application.DTO;

//dto tương ứng với class Genre
public class GenreResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }

}