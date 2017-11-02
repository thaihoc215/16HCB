using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
            object content = new
            {
                mathe = 1,
                matkhau = 123,
                nganhang = 1
            };
            var response = client.PostAsync("/products", new StringContent(content.ToString())).Result;
            if (response.IsSuccessStatusCode) {
                var list = response.Content;
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
