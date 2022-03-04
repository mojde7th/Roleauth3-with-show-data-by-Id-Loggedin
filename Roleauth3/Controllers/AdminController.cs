using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Roleauth3.Controllers
{

    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
       
        public IActionResult Index()
        {
             return View();
        }
    }
}
