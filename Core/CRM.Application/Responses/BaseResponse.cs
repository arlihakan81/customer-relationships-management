using System.ComponentModel;

namespace CRM.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        public static BaseResponse<T> SuccessResult(int statusCode, T? data, string message = "İstek Başarılı")
        {
            return new BaseResponse<T> { Data = data, StatusCode = statusCode, Message = message };
        }

        public static BaseResponse<T> FailureResult(int statusCode, string message = "Birşeyler ters gitti", List<string>? errors = null)
        {
            return new BaseResponse<T> { StatusCode = statusCode, Message = message, Errors = errors };
        }


    }

    public class PagedResult<T>
    {
        public List<T>? Items { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedResult(List<T>? items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;            
        }



    }

}
