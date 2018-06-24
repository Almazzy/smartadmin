using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.Seed.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TopicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return PartialView("_TopicData");
        }
    }
}
