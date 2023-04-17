using Library;
using Newtonsoft.Json.Linq;
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
        private string base_uri = "https://telcohub-demo.vtctelecom.com.vn/api/";
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

        public async Task<JsonResult> Index()
        {
            JsonResult jr = new JsonResult();

            String partnerId = ConfigurationManager.AppSettings["PartnerId"];
            String secretKey = ConfigurationManager.AppSettings["SecretKey"];
            string address = "Tỉnh Tiền Giang";
            string fullname = "Nguyễn Duy";
            string refId = "578345";
            string phone = "84765063660";
            string productCode = "2022011202";
            string sign = $"{address},{fullname},{partnerId},{phone},{productCode},{refId},{secretKey}";
            var sign_activate_hash = Hash.GetHash(sign, Hash.HashType.MD5);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_uri);

            var activatedata = await client.GetAsync("partner/activate/?address=" + address + "&fullname=" + fullname + "&partnerId=" + partnerId + "&phone=" + phone + "&productCode=" + productCode + "&refId=" + refId + "&sign=" + sign_activate_hash);
            //var conten_shippingdata = shippingdata.Content.ReadAsStringAsync();
            JObject jsonObj = JObject.Parse(activatedata.Content.ReadAsStringAsync().Result);
            if ((string)jsonObj["result"] == "1")
            {
                string sign_shippingdata_hash = Hash.GetHash($"{partnerId},{refId},{secretKey}", Hash.HashType.MD5);
                var shippingdata = await client.GetAsync("partner/getShippingData?partnerId=" + partnerId + "&refId=" + refId + "&sign=" + sign_shippingdata_hash);
                JObject jsonshippingdata = JObject.Parse(shippingdata.Content.ReadAsStringAsync().Result);
                //JArray data = (JArray)jsonshippingdata["data"];

                string key_value = jsonshippingdata["data"][0]["detail"]["keyList"][0]["value"].ToString();
            }
            jr.Data = new
            {
                status = "Dữ liệu nhận thành công",
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }


    }
}