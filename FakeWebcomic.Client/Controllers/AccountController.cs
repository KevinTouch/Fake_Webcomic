using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;


namespace FakeWebcomic.Client.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        public IActionResult SignInOkta()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Archive", "Main");
        }

        [HttpPost]
        public IActionResult SignOutOkta()
        {
            return new SignOutResult(
                new[]
                {
                        OktaDefaults.MvcAuthenticationScheme,
                        CookieAuthenticationDefaults.AuthenticationScheme
                },
                new AuthenticationProperties { RedirectUri = "/Main/" });
        }
    }
}
