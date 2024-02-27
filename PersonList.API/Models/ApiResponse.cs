using System.Net;

namespace PersonList.Application.Models
{
    public class ApiResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool isSuccess { get; set; } = true;
        public List<string> errorList { get; set; } = new List<string>();
        public object? result { get; set; }
    }
}
