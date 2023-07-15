namespace SmartAPI.Models.Result
{
    public class Response
    {
        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
    }
}
