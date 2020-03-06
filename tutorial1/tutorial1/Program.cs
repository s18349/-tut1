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
            var websiteURl = args.Length > 0 ? args[0] : throw new ArgumentNullException();
         
            var httpClinet = new HttpClient();
            try
            {
                var response = await httpClinet.GetAsync(websiteURl);
                httpClinet.Dispose(); // after using httpclint we delete
           
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync(); //asyncronise is always with await

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.+[a-z]", RegexOptions.IgnoreCase); //extract only email/ all captal treat as lowercase

                    var emailAdresses = regex.Matches(htmlContent);

                    if(emailAdresses.Count > 0)
                    {
                        foreach (var emailAddress in emailAdresses)
                        {
                            Console.WriteLine(emailAddress.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("no enmail adresses is found");
                    }
                    

                }
            }
            catch
            {
                Console.WriteLine("Error while downloading the page");
            }

           

            Console.ReadKey();
        }

    }
}
