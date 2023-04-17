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
        public async Task<string> Send_KeyAsync(string partnerId, string secretKey)
        {
            string sign = $"{partnerId},0765063660,{secretKey}";
            var sign_hash = Hash.GetHash(sign, Hash.HashType.MD5);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://telcohub-demo.vtctelecom.com.vn/api/");

            var shippingdata = await client.GetAsync("");
            var conten_shippingdata = shippingdata.Content.ReadAsStringAsync();
            return sign_hash;
        }
        public static string hash_sign(string partnerId, string secretKey)
        {
            string sign = "20210037,578098,7d2031abadb945bf913f3d9a9d829910";
            var sign_hash = Hash.GetHash(sign, Hash.HashType.MD5);
            return sign_hash;
        }
    }
}
