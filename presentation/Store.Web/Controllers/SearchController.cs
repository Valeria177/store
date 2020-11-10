using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDetailRepository detailRepository;

        public SearchController(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }
        public IActionResult Index(string querty)
        {
            var details = detailRepository.GetAllByTitle(querty);

            return View(details);
        }
    }
}