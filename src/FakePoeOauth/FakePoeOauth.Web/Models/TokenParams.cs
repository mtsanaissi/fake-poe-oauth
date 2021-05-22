using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakePoeOauth.Web.Models
{
    public class TokenParams
    {
        // I know the property names are ugly, it's just to make it easy
        // on the mapping from/to query url

        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
        public string code { get; set; }
        public string redirect_uri { get; set; }
        public string scope { get; set; }
    }
}
