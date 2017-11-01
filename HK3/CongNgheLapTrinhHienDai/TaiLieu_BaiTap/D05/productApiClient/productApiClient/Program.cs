using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace productApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/products").Result;
            if (response.IsSuccessStatusCode) {
                var list = response.Content.ReadAsAsync<Product[]>().Result;
                Console.WriteLine(list.Length);
            }
        }
    }

    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int price { get; set; }
    }
}
