namespace GST_API.APIModels
{
    public class ResponseModel
    {
        public string message { get; set; } = "success";
        public object? data { get; set; } = null;
        public bool? isSuccess { get; set; } = true;
    }
}
