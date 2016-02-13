using gitInsta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace gitInsta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var cookie = Request.Cookies["autorCoockie"];
            if (cookie == null) 
                return View("AutoView");
            return View();
        }

        [HttpPost]
        public ActionResult Index(loginpass lp)
        {
           if (ModelState.IsValid)//если модель валидна, всё заполнено верно
            {
                if (lp.login == "admin")//если условие выполнилось
                {
                    var cookie = new HttpCookie("autorCoockie")
                    {
                        Name = "autorCoockie",
                        Value = lp.login,
                        Expires = DateTime.Now.AddMinutes(5),
                    };
                    Response.SetCookie(cookie);
                    return View();
                }
                return View("AutoView");
            }
            return View("AutoView", lp);


        }

        public ActionResult IsGood()
        {
            MsSQL sql = new MsSQL();
            ViewBag.Datanow = sql.Scalar("SELECT COUNT(*) FROM dbo.users");
            
            return View();
        }


    }
}