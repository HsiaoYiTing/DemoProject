public class ResponseFactory
{
    public static ResponseBase<T> CreateSuccessResponse<T>(T data, string message = "Success")
    {
        return new ResponseBase<T>
        {
            Code = 200,
            Message = message,
            Data = data
        };
    }

     public static ResponseBase<T> CreateErrorResponse<T>(T data, string message = "Error")
    {
        return new ResponseBase<T>
        {
            Code = 500,
            Message = message,
            Data = data
        };
    }

     public static ResponseBase CreateSuccessResponse(string message = "Success")
    {
        return new ResponseBase
        {
            Code = 200,
            Message = message
        };
    }

    public static ResponseBase CreateErrorResponse(string message = "Error")
    {
        return new ResponseBase
        {
            Code = 500,
            Message = message
        };
    }
}