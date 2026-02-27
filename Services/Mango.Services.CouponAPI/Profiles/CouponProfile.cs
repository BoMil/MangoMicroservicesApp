using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>();

            // This will ensure that old data is not overwritten
            CreateMap<CouponDto, Coupon>()
                .ForMember(dest => dest.CouponCode, opt => opt.Condition(src => src.CouponCode != null))
                .ForMember(dest => dest.DiscountAmount, opt => opt.Condition(src => src.DiscountAmount.HasValue))
                .ForMember(dest => dest.MinAmount, opt => opt.Condition(src => src.MinAmount.HasValue))
                .ForMember(dest => dest.LastUpdated, opt => opt.Ignore());
        }
    }
}