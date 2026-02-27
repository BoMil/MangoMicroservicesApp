using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.CouponAPI.Models.Dto
{
    public class ResponseDto<T>
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T? Result { get; set; }
    }
}