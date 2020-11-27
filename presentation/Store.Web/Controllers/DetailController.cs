using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Memory;

namespace Store.Web.Controllers
{

    public class DetailController : Controller
    {
        private readonly IDetailRepository detailRepository;

        public DetailController(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }
        public IActionResult Index(int id)
        {

            Detail detail = detailRepository.GetById(id);
            return View(detail);
        }
    }
}