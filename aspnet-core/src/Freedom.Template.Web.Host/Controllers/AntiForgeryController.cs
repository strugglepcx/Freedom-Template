using Microsoft.AspNetCore.Antiforgery;
using Freedom.Template.Controllers;

namespace Freedom.Template.Web.Host.Controllers
{
    public class AntiForgeryController : TemplateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
