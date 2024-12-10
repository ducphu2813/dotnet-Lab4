namespace Domain.Entities;

public class Cart : BaseEntity
{
    public string? Code { get; set; }
    public string? Note { get; set; }
    public bool Status { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedOn { get; set; }

    //quan hệ tới CartDetail
    public ICollection<CartDetail> CartDetails { get; set; }
}