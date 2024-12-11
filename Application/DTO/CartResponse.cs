namespace Application.DTO;

//dto tương ứng với class Cart
public class CartResponse
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Note { get; set; }
    public bool Status { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedOn { get; set; }
    
    //danh sách chi tiết giỏ hàng
    public ICollection<CartDetailResponse> CartDetails { get; set; }
}