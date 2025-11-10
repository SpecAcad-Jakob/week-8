using System.Net.Http.Json;
using W3___REST_API;

namespace HttpClientTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("127.0.0.1:7065");

            CerealItem? response = await httpClient.GetFromJsonAsync<CerealItem>("/partial1");
            Console.WriteLine(response);
        }
    }
}
