using System.Text.Json.Serialization;

namespace Core.Dtos
{
    public class RestResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } //json dönüştürürken ignore olacak

        public List<string> Errors { get; set; }

        public static RestResponseDto<T> Success(int statusCode, T data)
        {
            return new RestResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static RestResponseDto<T> Success(int statusCode)
        {
            return new RestResponseDto<T> { StatusCode = statusCode };
        }

        public static RestResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new RestResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static RestResponseDto<T> Fail(int statusCode, string error)
        {
            return new RestResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
