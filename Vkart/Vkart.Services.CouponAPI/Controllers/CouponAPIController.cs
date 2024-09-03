using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vkart.Services.CouponAPI.Data;
using Vkart.Services.CouponAPI.Models;
using Vkart.Services.CouponAPI.Models.DTOs;

namespace Vkart.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto GetCoupon()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetCoupon(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(x =>x.CouponId==id);
                _responseDto.Result  = _mapper.Map<CouponDto>(objList);
                
            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetCoupon(string code)
        {
            try
            {
                Coupon objList = _db.Coupons.FirstOrDefault(x => x.Couponcode.ToLower() == code.ToLower());
                if(objList == null)
                {
                    _responseDto.IsSUccess=false;
                }
                _responseDto.Result = _mapper.Map<CouponDto>(objList);

            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto CreateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto UpdateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpDelete]
        public ResponseDto DeleteCoupon(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x =>x.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSUccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
