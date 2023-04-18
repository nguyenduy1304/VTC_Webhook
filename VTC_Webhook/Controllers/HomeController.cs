using Library;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Persistence;
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
        private string base_uri = ConfigurationManager.AppSettings["Base_Uri"];
        private string partnerId = ConfigurationManager.AppSettings["PartnerId"];
        private string secretKey = ConfigurationManager.AppSettings["SecretKey"];

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
            string address = "Tỉnh Tiền Giang";
            string fullname = "Nguyễn Duy";
            string refId = "00000581796 ";
            string phone = "84765063660";
            string productCode_apaha = "720878";

            HttpClient client = new HttpClient();

            /*var send_sms = await client.GetAsync("http://10.0.0.91:8899/SmsService/Send/?from=849109&to=0765063660&message=MB4SR-UOZEH-51RVC-K5CLO");
            JObject rs = JObject.Parse(send_sms.Content.ReadAsStringAsync().Result);*/

            client.BaseAddress = new Uri(base_uri);
            using (Connection connection = new Connection())
            {
                var vTC_MapProduct = connection.VTC_MapProducts.FirstOrDefault(p => p.Abaha_Product_Code == productCode_apaha);
                if (vTC_MapProduct != null)
                {
                    var sign_activate_hash = Hash.GetHash($"{address},{fullname},{partnerId},{phone},{vTC_MapProduct.VTC_Product_Code},{refId},{secretKey}", Hash.HashType.MD5);
                    var activatedata = await client.GetAsync("partner/activate/?address=" + address + "&fullname=" + fullname + "&partnerId=" + partnerId + "&phone=" + phone + "&productCode=" + vTC_MapProduct.VTC_Product_Code + "&refId=" + refId + "&sign=" + sign_activate_hash);
                    JObject jsonObj = JObject.Parse(activatedata.Content.ReadAsStringAsync().Result);

                    if ((string)jsonObj["result"] == "1")
                    {
                        string sign_shippingdata_hash = Hash.GetHash($"{partnerId},{refId},{secretKey}", Hash.HashType.MD5);
                        var shippingdata = await client.GetAsync("partner/getShippingData?partnerId=" + partnerId + "&refId=" + refId + "&sign=" + sign_shippingdata_hash);
                        JObject jsonshippingdata = JObject.Parse(shippingdata.Content.ReadAsStringAsync().Result);

                        //string key_value = jsonshippingdata["data"][0]["detail"]["keyList"][0]["value"].ToString();
                        VTC_Orders vTC_Orders = new VTC_Orders();
                        vTC_Orders.Id = Guid.NewGuid().ToString();
                        vTC_Orders.FullName = fullname;
                        vTC_Orders.Address = address;
                        vTC_Orders.Phone = phone;
                        vTC_Orders.RefId = jsonshippingdata["data"][0]["refId"].ToString();
                        vTC_Orders.Abaha_Product_Code = productCode_apaha;
                        vTC_Orders.Key_Value = jsonshippingdata["data"][0]["detail"]["keyList"][0]["value"].ToString();
                        vTC_Orders.ActivationDate = DateTime.Parse(jsonshippingdata["data"][0]["detail"]["validFrom"].ToString());
                        vTC_Orders.Expires = DateTime.Parse(jsonshippingdata["data"][0]["detail"]["ValidTo"].ToString());
                        vTC_Orders.RequestId_Activate = jsonObj["requestId"].ToString();
                        vTC_Orders.RequestId_ShippingData = jsonshippingdata["requestId"].ToString();
                        vTC_Orders.Product_Code = vTC_MapProduct.VTC_Product_Code;
                        vTC_Orders.Status_sms = false;
                        connection.VTC_Orders.Add(vTC_Orders);
                        connection.SaveChanges(); 

                        // tới đây gửi key về cho khách hàng \
                    }
                }
            }
            JsonResult jr = new JsonResult();
            jr.Data = new
            {
                status = "Thành công !!!",
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}