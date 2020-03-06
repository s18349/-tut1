using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial1
{
    public class Test
    {
        public static async Task Main(String[] args)
        {
            var websiteURl = args[0];
            var httpClinet = new HttpClient();
            var response = await httpClinet.GetAsync(websiteURl);
            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync(); //asyncronise is always with await

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.+[a-z]", RegexOptions.IgnoreCase); //extract only email/ all captal treat as lowercase

                var emailAdresses = regex.Matches(htmlContent);

                foreach ( var emailAddress in emailAdresses)
                {
                    Console.WriteLine(emailAddress.ToString());
                }

            }

            Console.ReadKey();
        }

    }
}
