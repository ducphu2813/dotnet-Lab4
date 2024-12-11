namespace Application.DTO;

public class SaveCart
{
    public string? Code { get; set; }
    public string? Note { get; set; }
    public bool Status { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedOn { get; set; }
}