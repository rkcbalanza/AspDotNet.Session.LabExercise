using Microsoft.AspNetCore.Mvc;
using ToyUniverseData.Repositories;
using ToyUniverseWeb.Services;

namespace ToyUniverseWeb.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyService _toyService;

        public ToyController(IToyRepository toyRepository, IToyService toyService)
        {
            this._toyService = toyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(this._toyService.GetToyPage(1,10));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex, int pageSize)
        {
            return View(this._toyService.GetToyPage(currentPageIndex,pageSize));
        }
    }
}
