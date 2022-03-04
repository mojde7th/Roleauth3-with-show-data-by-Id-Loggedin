using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roleauth3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleauth3.Controllers
{
    public class MelinaftController : Controller
    {
        

     
        [Authorize(Roles = "Melinaft")]
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
