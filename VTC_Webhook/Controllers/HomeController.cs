using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VTC_Webhook.Controllers
{
    public class HomeController : Controller
    {
        
        public JsonResult Getdata()
        {
            JsonResult jr = new JsonResult();

            String dataJson= new StreamReader(Request.InputStream).ReadToEnd();

            jr.Data = new
            {
                status = "Dữ liệu nhận thành công",
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            ViewBag.partnerId = ConfigurationManager.AppSettings["PartnerId"];
            ViewBag.secretKey = ConfigurationManager.AppSettings["SecretKey"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}