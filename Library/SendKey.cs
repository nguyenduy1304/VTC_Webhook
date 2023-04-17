using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SendKey
    {
        private string base_uri = "https://telcohub-demo.vtctelecom.com.vn/api/";
        private string address = "Tỉnh Tiền Giang";
        private string fullname = "Nguyễn Duy";
        private string refId = "578345";
        private string phone = "84765063660";
        private string productCode = "2022011202";

        


        public async Task Send_KeyAsync(string partnerId, string secretKey)
        {
            string sign = $"{address},{fullname},{partnerId},{phone},{productCode},{refId},{secretKey}";
            var sign_hash = Hash.GetHash(sign, Hash.HashType.MD5);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_uri);

            var shippingdata = await client.GetAsync("partner/activate/?address=Tỉnh Tiền Giang&fullname=Nguyễn Duy&partnerId=20210037&phone=84765063660&productCode=2022011202&refId=578345&sign=3995d423e3e4792409ecbb03c3c64009");
            var conten_shippingdata = shippingdata.Content.ReadAsStringAsync();
        }

        /*public static string hash_sign(string partnerId, string secretKey)
        {
            string sign = "20210037,578098,7d2031abadb945bf913f3d9a9d829910";
            var sign_hash = Hash.GetHash(sign, Hash.HashType.MD5);
            return sign_hash;
        }*/
    }
}
