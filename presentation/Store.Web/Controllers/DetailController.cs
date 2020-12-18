using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Web.App;

namespace Store.Web.Controllers
{

    public class DetailController : Controller
    {
        private readonly DetailService detailService;

        public DetailController(DetailService detailService)
        {
            this.detailService = detailService;
        }
        public IActionResult Index(int id)
        {

            var model = detailService.GetById(id);
            return View(model);
        }
    }
}