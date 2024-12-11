namespace Application.DTO;

//dto tương ứng với class CartDetail
public class CartDetailResponse
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    // Book
    public BookResponse Book { get; set; }
}