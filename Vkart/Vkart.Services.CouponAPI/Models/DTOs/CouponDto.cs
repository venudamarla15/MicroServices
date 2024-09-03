namespace Vkart.Services.CouponAPI.Models.DTOs
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string Couponcode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
