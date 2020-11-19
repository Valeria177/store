using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly DetailService detailService;


        public SearchController(DetailService detailService)
        {
            this.detailService = detailService;
        }
        public IActionResult Index(string querty)
        {
            var details = detailService.GetAllByQuery(querty);

            return View(details);
        }
    }
}