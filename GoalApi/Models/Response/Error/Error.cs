using System.Collections.Generic;

namespace Response.Error
{
    public class Error
    {
        public int Status { get; set; }
        public string Action { get; set; }
        public string Request { get; set; }
        public string Message { get; set; }
    }
}
