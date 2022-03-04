
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Roleauth3.Data;
using Roleauth3.Models;
using Roleauth3.services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Roleauth3.Controllers
{
    

    public class HomeController : Controller
        
    {

       
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        string mainconn = @"Data Source=(local);Initial Catalog=tes4;Integrated Security=True;";
        

        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        

        public IActionResult Index()
        {

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            ViewData["idd"] = userId;
            DataTable dt = new DataTable();
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
            
                string sqlquery = "select * from [tes4].[dbo].[AspNetUsers] where Id='"+ ViewData["idd"]+"'";
                //sqlcomm.CommandText = sqlquery;
                //sqlcomm.Connection = sqlconn;
                SqlDataAdapter sda = new SqlDataAdapter(sqlquery,sqlconn);
                sda.Fill(dt);
            }
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
           
            return View(dt);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
