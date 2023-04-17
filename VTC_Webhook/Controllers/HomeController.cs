using Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace VTC_Webhook.Controllers
{
    public class HomeController : Controller
    {
        private string base_uri ="https://telcohub-demo.vtctelecom.com.vn/api/";
        public JsonResult Getdata()
        {
            JsonResult jr = new JsonResult();

            String dataJson = new StreamReader(Request.InputStream).ReadToEnd();

            jr.Data = new
            {
                status = "Dữ liệu nhận thành công",
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetShippingData()
        {
            JsonResult jr = new JsonResult();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_uri);

            var shippingdata = await client.GetAsync("");
            var conten_shippingdata = shippingdata.Content.ReadAsStringAsync();


            jr.Data = new
            {
                status = "Dữ liệu nhận thành công",
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            String partnerId = ConfigurationManager.AppSettings["PartnerId"];
            String secretKey = ConfigurationManager.AppSettings["SecretKey"];
            ViewBag.hash = SendKey.hash_sign(partnerId,secretKey);
            return View();
        }

        
    }
}