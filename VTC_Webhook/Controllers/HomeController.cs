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
using System.Xml.Linq;

namespace VTC_Webhook.Controllers
{
    public class HomeController : Controller
    {
        private string base_uri = ConfigurationManager.AppSettings["Base_Uri"];
        private string partnerId = ConfigurationManager.AppSettings["PartnerId"];
        private string secretKey = ConfigurationManager.AppSettings["SecretKey"];

        public async Task<JsonResult> PushData()
        {
            // nhận data từ webhook
            //String jsonString = new StreamReader(Request.InputStream).ReadToEnd();


            // data mẫu
            string jsonString = "{\r\n  \"data_type\": \"cart\",\r\n  \"type\": \"update_order\",\r\n  \"id\": \"29137\",\r\n  \"created\": \"2023-04-19 08:39:52\",\r\n  \"summary\": \"Cập nhật đơn hàng\",\r\n  \"data\": {\r\n    \"id\": \"582568\",\r\n    \"cart_code\": \"00000582568\",\r\n    \"cart_type\": \"cart\",\r\n    \"user_id\": \"4293373\",\r\n    \"ref_user_id\": null,\r\n    \"payment_type\": \"1\",\r\n    \"payment_content\": \"\",\r\n    \"promotion_id\": \"0\",\r\n    \"user_voucher_id\": null,\r\n    \"voucher_status\": \"0\",\r\n    \"total_value\": \"900000\",\r\n    \"total_after\": \"900000\",\r\n    \"total_cashback\": null,\r\n    \"fee_ship\": null,\r\n    \"weight\": \"0\",\r\n    \"wallet_fee\": [],\r\n    \"commission_ref\": null,\r\n    \"dropship_commission_ref\": null,\r\n    \"accept_commission_ref\": \"0\",\r\n    \"cashback\": [],\r\n    \"total_before\": \"900000\",\r\n    \"total_cal_commission\": \"900000\",\r\n    \"total_discount_value\": \"0\",\r\n    \"total_count_selected\": \"4\",\r\n    \"count_selected\": \"2\",\r\n    \"status\": \"10\",\r\n    \"before_status\": null,\r\n    \"address_id\": \"175956\",\r\n    \"store_id\": null,\r\n    \"user_note\": null,\r\n    \"site_note\": \"\",\r\n    \"payment\": \"Khi nhận hàng (COD)\",\r\n    \"payment_method_id\": null,\r\n    \"payment_id\": null,\r\n    \"payment_status\": 5,\r\n    \"txn_id\": null,\r\n    \"item_fee\": {\r\n      \"Phí Ship\": \"Chưa tính\"\r\n    },\r\n    \"used_wallets\": [],\r\n    \"wallet_option\": [],\r\n    \"cart_fees\": null,\r\n    \"commerce_fee\": null,\r\n    \"is_reject\": \"0\",\r\n    \"commissions\": [],\r\n    \"orders_time\": \"2023-04-19 08:00:27\",\r\n    \"delete_flag\": \"0\",\r\n    \"delivery_time\": null,\r\n    \"utm_source\": \"Web\",\r\n    \"modified\": \"2023-04-19 08:39:52\",\r\n    \"created\": \"2023-04-19 07:59:56\",\r\n    \"accept_commission_ref_date\": null,\r\n    \"comment\": \"\",\r\n    \"comment_time\": null,\r\n    \"star\": null,\r\n    \"pricing_id\": null,\r\n    \"cart_type_name\": \"Đơn hàng\",\r\n    \"count\": 0,\r\n    \"user\": {\r\n      \"user_id\": \"4293373\",\r\n      \"name\": \"Nguyễn Duy\"\r\n    },\r\n    \"pos_details\": \"\",\r\n    \"promotions\": [],\r\n    \"address\": {\r\n      \"id\": \"175956\",\r\n      \"user_id\": \"4293373\",\r\n      \"name\": \"Duy Tiền Giang\",\r\n      \"tel\": \"0369852701\",\r\n      \"address\": \"Quí Thạnh(Xã Tân Hội,Thị xã Cai Lậy,Tỉnh Tiền Giang)\",\r\n      \"province_id\": \"82\",\r\n      \"district_id\": \"917\",\r\n      \"ward_id\": \"29542\",\r\n      \"city\": \"Tỉnh Tiền Giang\",\r\n      \"district\": \"Thị xã Cai Lậy\",\r\n      \"ward\": \"Xã Tân Hội\",\r\n      \"latitude\": \"10.4205786\",\r\n      \"longitude\": \"106.1639749\",\r\n      \"default_flag\": \"0\",\r\n      \"delete_flag\": \"0\",\r\n      \"modified\": \"2023-04-18 10:05:38\",\r\n      \"created\": \"2023-04-17 14:15:14\"\r\n    },\r\n    \"name_payment_method\": \"Khi nhận hàng (COD)\",\r\n    \"store_name\": \"\",\r\n    \"pricing_name\": \"\",\r\n    \"payment_status_name\": \"Chưa thanh toán\",\r\n    \"products\": [\r\n      {\r\n        \"name\": \"Phần mềm Kaspersky Internet Security - Multi-Device 1DC/Năm\",\r\n        \"product_id\": \"720865\",\r\n        \"quantity\": \"2\",\r\n        \"price\": \"150000\",\r\n        \"total_price\": \"300000\",\r\n        \"model\": \"\"\r\n      },\r\n      {\r\n        \"name\": \"Phần mềm Kaspersky Internet Security - Multi-Device 3DC/Năm\",\r\n        \"product_id\": \"720875\",\r\n        \"quantity\": \"2\",\r\n        \"price\": \"300000\",\r\n        \"total_price\": \"600000\",\r\n        \"model\": \"\"\r\n      }\r\n    ]\r\n  },\r\n  \"header\": []\r\n}";
            
            JToken jToken = JToken.Parse(jsonString);
            string fullname = (string)jToken["data"]["user"]["name"];
            string address = (string)jToken["data"]["address"]["address"];
            string refId = (string)jToken["data"]["id"];
            string phone = (string)jToken["data"]["address"]["tel"];
            if (phone.StartsWith("0"))
            {
                phone = "84" + phone.Substring(1);
            }
            string payment_status = (string)jToken["data"]["payment_status"];
            if ((string)jToken["data"]["payment_status"] == "5")
            {
                String Send_Messager = "KEY KÍCH HOẠT\n";
                using (Connection connection = new Connection())
                {
                    var checkorder = connection.VTC_Orders.FirstOrDefault(o => o.RefId == refId);
                    if (checkorder == null)
                    {
                        VTC_Orders vTC_Orders = new VTC_Orders();
                        vTC_Orders.RefId = refId;
                        vTC_Orders.UserId = (string)jToken["data"]["user"]["user_id"];
                        vTC_Orders.FullName = fullname;
                        vTC_Orders.Address = address;
                        vTC_Orders.Phone = phone;
                        vTC_Orders.OrdersTime = (DateTime)jToken["data"]["orders_time"];
                        vTC_Orders.Total = (string)jToken["data"]["total_cal_commission"];
                        vTC_Orders.Status_sms = false;
                        connection.VTC_Orders.Add(vTC_Orders);
                    }
                    else
                    {
                        checkorder.UserId = (string)jToken["data"]["user"]["user_id"];
                        checkorder.FullName = fullname;
                        checkorder.Address = address;
                        checkorder.Phone = phone;
                        checkorder.Total = (string)jToken["data"]["total_cal_commission"];
                        checkorder.Status_sms = false;
                    }
                    connection.SaveChanges();
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(base_uri);
                    dynamic data = JsonConvert.DeserializeObject(jsonString);
                    int ref_order = 1;
                    foreach (var product in data.data.products)
                    {
                        for (int i = 1; i <= (int)product.quantity; i++)
                        {
                            string productId = product.product_id;
                            var vTC_MapProduct = connection.VTC_MapProducts.FirstOrDefault(p => p.Abaha_Product_Code == productId);
                            if (vTC_MapProduct != null)
                            {
                                string ref_order_request = refId + "_" + ref_order + "_" + i.ToString();
                                var sign_activate_hash = Hash.GetHash($"{address},{fullname},{partnerId},{phone},{vTC_MapProduct.VTC_Product_Code},{ref_order_request},{secretKey}", Hash.HashType.MD5);
                                var activatedata = await client.GetAsync("partner/activate/?address=" + address + "&fullname=" + fullname + "&partnerId=" + partnerId + "&phone=" + phone + "&productCode=" + vTC_MapProduct.VTC_Product_Code + "&refId=" + ref_order_request + "&sign=" + sign_activate_hash);
                                JObject jsonObj = JObject.Parse(activatedata.Content.ReadAsStringAsync().Result);
                                if ((string)jsonObj["result"] == "1")
                                {
                                    string sign_shippingdata_hash = Hash.GetHash($"{partnerId},{ref_order_request},{secretKey}", Hash.HashType.MD5);
                                    var shippingdata = await client.GetAsync("partner/getShippingData?partnerId=" + partnerId + "&refId=" + ref_order_request + "&sign=" + sign_shippingdata_hash);
                                    JObject jsonshippingdata = JObject.Parse(shippingdata.Content.ReadAsStringAsync().Result);
                                    VTC_Order_Detail vTC_Order_Detail = new VTC_Order_Detail();
                                    vTC_Order_Detail.Id = Guid.NewGuid().ToString();
                                    vTC_Order_Detail.RefId_Abaha = refId;
                                    vTC_Order_Detail.RefId_Telcohub = ref_order_request;
                                    vTC_Order_Detail.Key_Value = jsonshippingdata["data"][0]["detail"]["keyList"][0]["value"].ToString();
                                    vTC_Order_Detail.ActivationDate = DateTime.Parse(jsonshippingdata["data"][0]["detail"]["validFrom"].ToString());
                                    vTC_Order_Detail.Expires = DateTime.Parse(jsonshippingdata["data"][0]["detail"]["ValidTo"].ToString());
                                    vTC_Order_Detail.Abaha_Product_Code = productId;
                                    vTC_Order_Detail.RequestId_Activate = jsonObj["requestId"].ToString();
                                    vTC_Order_Detail.RequestId_ShippingData = jsonshippingdata["requestId"].ToString();
                                    vTC_Order_Detail.Product_Code = vTC_MapProduct.VTC_Product_Code;

                                    connection.VTC_Order_Detail.Add(vTC_Order_Detail);
                                    Send_Messager += vTC_MapProduct.ShortName + ":" + jsonshippingdata["data"][0]["detail"]["keyList"][0]["value"].ToString() + "\n";
                                }
                            }
                        }
                        ref_order++;
                        connection.SaveChanges();
                    }
                    string phone_to = (string)jToken["data"]["address"]["tel"];
                    HttpClient client_send_sms = new HttpClient();

                    //\/\/\/\ 10.0.0.91 /\/\/\/\
                    var send_response = await client_send_sms.GetAsync("http://10.0.0.91:8899/SmsService/Send/?from=849109&to=" + phone_to + "&message=" + Send_Messager);
                    JObject send_json = JObject.Parse(send_response.Content.ReadAsStringAsync().Result);
                    if (send_json["ErrorMessage"].ToString() == null || send_json["ErrorMessage"].ToString() == "")
                    {
                        var check_status_sms = connection.VTC_Orders.FirstOrDefault(o => o.RefId == refId);

                        check_status_sms.Status_sms = true;
                        connection.SaveChanges();
                    }
                }
            }
            JsonResult jr = new JsonResult();
            jr.Data = new
            {
                status = 200,
                Messager = "Success",
                data = ""
            };
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}