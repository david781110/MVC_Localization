using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace MVC_Localization.Controllers
{
    public class BaseController : Controller
    {
        string CookieKey = "CultureInfo";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string CultureName = "";
            if (Request.Cookies.ContainsKey(CookieKey))
            {
                CultureName = Request.Cookies[CookieKey];
            }
            else
            {
                CultureName = Request.Headers["accept-language"][0].Split(',')[0];
            }

            Thread.CurrentThread.CurrentCulture=Thread.CurrentThread.CurrentUICulture=new System.Globalization.CultureInfo(CultureName);
            base.OnActionExecuting(context);
        }

        public IActionResult SetLanguage(string CultureName)
        {
            SetCookie(CultureName);
            string Referer = Request.Headers["referer"];
            return Redirect(Referer);
        }

        private void SetCookie(string CultureName)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddYears(1);
            options.Secure = true;
            options.HttpOnly = true;
            Response.Cookies.Delete(CookieKey);
            Response.Cookies.Append(CookieKey, CultureName, options);
        }
    }
}
