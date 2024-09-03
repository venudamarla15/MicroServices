namespace Vkart.Services.CouponAPI.Models.DTOs
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSUccess { get; set; } = true;
        public string Message { get; set; } = "";

    }
}
