using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FakePoeOauth.Web.Models
{
    public class AuthorizeParams
    {
        // I know the property names are ugly, it's just to make it easy
        // on the mapping from/to query url

        public string client_id { get; set; }
        public string response_type { get; set; }
        public string scope { get; set; }
        public string state { get; set; }
        public string redirect_uri { get; set; }
        public string prompt { get; set; }
    }
}
