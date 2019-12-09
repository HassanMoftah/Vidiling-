using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidiling.Models;
using Vidiling.ViewModel;
namespace Vidiling.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
           
            return View();
        }
    }
}