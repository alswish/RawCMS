using System;
using System.Collections.Generic;
using System.Text;

namespace RawCMS.Plugins.ApiGateway.Classes.Models
{
    public class LogEntity
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public string Ip { get; set; }
        public string RequestHeaders { get; set; }
        public string RequestContent { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponseContent { get; set; }
        public int ResponseStatus { get; set; }
        public DateTime RequestOn { get; set; }
    }
}
