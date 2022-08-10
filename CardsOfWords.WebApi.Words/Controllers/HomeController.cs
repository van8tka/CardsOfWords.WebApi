using Microsoft.AspNetCore.Mvc;

namespace CardsOfWords.WebApi.Words.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
