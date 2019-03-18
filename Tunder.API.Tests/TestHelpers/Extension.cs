using System;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tunder.API.Tests.TestHelpers
{
    public static class Extension
    {
        public static void SetUserClaimId(this ControllerBase controller, Guid guid)
        {
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, guid.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims);


            var principal = new ClaimsPrincipal(claimsIdentity);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() {User = principal}
            };
        }
    }
}