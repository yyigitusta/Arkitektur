using Artitektur.Business.DTOs.BannerDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artitektur.Business.BaseDtos
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public IEnumerable<Object> Errors { get; set; }
        [JsonIgnore]
        public bool IsSuccess => Errors == null || !Errors.Any();
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;


        public static BaseResult<T> Success(T data)
        {
            return new BaseResult<T> { Data = data };
        }
        public static BaseResult<T> Fail(string errorMessage)
        {
            return new BaseResult<T> { Errors = new[] { new { ErrorMessage = errorMessage } } };
        }

        public static async Task<BaseResult<List<ResultBannerDto>>> Success(List<ResultBannerDto> mappedResult)
        {
            throw new NotImplementedException();
        }
        public static BaseResult<T> Fail(IEnumerable<IdentityError> errorMessages)
        {
            IEnumerable<object> errors=(from error in errorMessages
                                        select new 
                                        { 
                                            error.Code,
                                            error.Description 
                                        }).ToList();
            return new BaseResult<T> { Errors=errors };
        }

    }
}
