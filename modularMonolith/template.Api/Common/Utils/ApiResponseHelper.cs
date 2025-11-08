namespace template.Api.Common.Utils
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> Success<T>(T value, string title = "Ok", string message = "success")
        {
            return new ApiResponse<T>()
            {
                Values = value,
                Title = title,
                Message = message,
                Error = false
            };

        }

        public static ApiResponse<T> Error<T>(T value, string title = "Error", string message = "there was an error, contact an admon")
        {
            return new ApiResponse<T>()
            {
                Values = value,
                Title = title,
                Message = message,
                Error = true
            };

        }
    }
}
