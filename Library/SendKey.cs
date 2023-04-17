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
        public async Task<String> Send_KeyAsync(string partnerId, string secretKey, string base_url)
        {
            string address = "Tỉnh Tiền Giang";
            string fullname = "Nguyễn Duy";
            string refId = "578345";
            string phone = "84765063660";
            string productCode = "2022011202";
            string sign = $"{address},{fullname},{partnerId},{phone},{productCode},{refId},{secretKey}";
            var sign_hash = Hash.GetHash(sign, Hash.HashType.MD5);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_url);

            var shippingdata = await client.GetAsync("partner/activate/?address=" + address + "&fullname=" + fullname + "&partnerId=" + partnerId + "&phone=" + phone + "&productCode=" + productCode + "&refId=" + refId + "&sign=" + sign_hash);
            var conten_shippingdata = shippingdata.Content.ReadAsStringAsync();
            return "Successfull";
        }


    }
}
