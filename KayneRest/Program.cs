using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;


namespace KayneRest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var client2 = new HttpClient();
            var ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            Console.WriteLine("Keep pressing Enter to experience a conversation between Kanye West and Ron Swanson");
            Console.ReadLine();
            for (var i = 0; i < 5; i++) 
            {
                var ronResponse = client2.GetStringAsync(ronSwansonURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron Swanson - {ronQuote}");
                Console.ReadLine();

                while(i < 5)
                {
                    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                    Console.WriteLine($"Kanye West - {kanyeQuote}");
                    Console.ReadLine();
                    break;
                }
                    
            }
            
        }
    }
}