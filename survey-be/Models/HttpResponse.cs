using System.Net;

namespace survey_be.Models
{
    public class HttpResponseSuccess
    {
        public HttpStatusCode status { get; set; }
        public string title { get; set; }
        public object data { get; set; }
    }

    public class HttpResponseError
    {
        public HttpStatusCode status { get; set; }
        public string title { get; set; }
        public object data { get; set; }
    }
}
