using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakePoeOauth.Web.Models;
using Flurl;
using Microsoft.AspNetCore.Mvc;

namespace FakePoeOauth.Web.Controllers
{
    [Route("oauth")]
    public class AuthorizationController : Controller
    {
        [HttpGet("authorize")]
        public IActionResult Authorize(AuthorizeParams parameters)
        {
            return View(parameters);
        }

        public RedirectResult Consent(AuthorizeParams parameters)
        {
            /*
            (https://www.pathofexile.com/developer/docs/authorization)
            On success the user will be redirected to your redirect_uri with a code and the state as query parameters.
            On failure the user will also be redirected to your redirect_uri with details according to Section 4.1.2.1.
            */

            var code = Guid.NewGuid();

            var url = parameters.redirect_uri
                .SetQueryParams(new
                {
                    code,
                    parameters.state
                });

            return Redirect(url);
        }

        [HttpPost("token")]
        public object GetToken([FromBody] TokenParams parameters)
        {
            switch (parameters.grant_type)
            {
                case "authorization_code":
                    return new
                    {
                        access_token = "486132c90fedb152360bc0e1aa54eea155768eb9",
                        expires_in = 2592000,
                        token_type = "bearer",
                        scope = "account:profile",
                        refresh_token = "17abaa74e599192f7650a4b89b6e9dfef2ff68cd"
                    };
                case "client_credentials":
                    string expires = null;
                    return new
                    {
                        access_token = "486132c90fedb152360bc0e1aa54eea155768eb9",
                        expires_in = expires,
                        token_type = "bearer",
                        scope = "service:psapi"
                    };
                case "refresh_token":
                    return new
                    {
                        access_token = "486132c90fedb152360bc0e1aa54eea155768eb9",
                        expires_in = 2592000,
                        token_type = "bearer",
                        scope = "account:profile"
                    };
                default:
                    return new
                    {
                        error = "Invalid grant type."
                    };
            }
        }
    }
}
