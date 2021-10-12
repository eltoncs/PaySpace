using System.Text.Json;

namespace PaySpaceApplication.Exceptions
{
    public class ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
