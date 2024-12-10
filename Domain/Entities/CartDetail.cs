namespace Domain.Entities;

public class CartDetail : BaseEntity
{
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    //khóa ngoại đến Book
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    
    //khóa ngoại đến Cart
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }

}