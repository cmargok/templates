namespace template.Api.Common.Utils
{
    public class ApiResponse<T>
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool Error { get; set; }
        public T? Values { get; set; }
    }
}
