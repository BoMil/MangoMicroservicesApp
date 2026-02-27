using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.CouponAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupons")]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<CouponDto>>> GetCoupons()
        {
            try
            {
                var coupons = await _db.Coupons.ToListAsync();
                var mappedCoupons = _mapper.Map<List<CouponDto>>(coupons);
                return new ResponseDto<IEnumerable<CouponDto>>
                {
                    Result = mappedCoupons,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<CouponDto>>
                {
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<CouponDto>> GetCoupon(int id)
        {
            var coupon = await _db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return new ResponseDto<CouponDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Coupon not found"
                };
            }

            var mappedCoupon = _mapper.Map<CouponDto>(coupon);

            return new ResponseDto<CouponDto>
            {
                Result = mappedCoupon,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success"
            };
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<ResponseDto<CouponDto>> GetCouponByCode(string code)
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponCode == code);

            if (coupon == null)
            {
                return new ResponseDto<CouponDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,

                    Message = $"Coupon with code {code} not found"
                };
            }

            var mappedCoupon = _mapper.Map<CouponDto>(coupon);

            return new ResponseDto<CouponDto>
            {
                Result = mappedCoupon,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success"
            };
        }

        [HttpPost("create-coupon")]
        public async Task<ResponseDto<CouponDto>> CreateCoupon([FromBody] CouponDto couponDto)
        {
            var coupon = _mapper.Map<Coupon>(couponDto);
            _db.Coupons.Add(coupon);
            await _db.SaveChangesAsync();


            return new ResponseDto<CouponDto>
            {
                Result = _mapper.Map<CouponDto>(coupon),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Coupon created successfully"
            };
        }

        [HttpPut("update-coupon")]
        public async Task<ResponseDto<CouponDto>> UpdateCoupon([FromBody] CouponDto couponDto)
        {
            // First check if coupon exits in the database
            var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponId == couponDto.CouponId);

            if (coupon == null)
            {
                return new ResponseDto<CouponDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Coupon not found"
                };
            }

            _mapper.Map(couponDto, coupon);
            coupon.LastUpdated = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return new ResponseDto<CouponDto>
            {
                Result = _mapper.Map<CouponDto>(coupon),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Coupon updated successfully"
            };

        }


        [HttpDelete("delete-coupon/{id}")]
        public async Task<ResponseDto<bool>> DeleteCoupon(int id)
        {
            var coupon = await _db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = $"Coupon with id {id} not found"
                };
            }

            _db.Coupons.Remove(coupon);
            await _db.SaveChangesAsync();

            return new ResponseDto<bool>
            {
                Result = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Coupon deleted successfully"
            };
        }
    }
}