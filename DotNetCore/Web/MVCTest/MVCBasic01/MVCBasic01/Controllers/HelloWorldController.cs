using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBasic01.Controllers
{
    public class HelloWorldController : Controller
    {
        //// GET: HelloWorld
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Get/HellowWorld/
        public string Index()
        {
            return "This is my <b>default</b> action...";
        }

        //GET: /HellowWorld/Welcome/
        public string Welcome(string Name, int NumTimes = 1) => HttpUtility.HtmlEncode("Hello " + Name + ", Numtimes is : " + NumTimes);
    }
}