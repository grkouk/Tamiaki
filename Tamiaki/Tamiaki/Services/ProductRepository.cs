using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Tamiaki.Models;

namespace Tamiaki.Services
{
    public class ProductRepository
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string WebApiBaseAddress
        {
            get => AppSettings.GetValueOrDefault(nameof(WebApiBaseAddress), "http://api.villakoukoudis.com/api");
            set => AppSettings.AddOrUpdateValue(nameof(WebApiBaseAddress), value);
        }
        public async Task<IEnumerable<Product>> GetSyncProductsAsync()
        {
            var httpClient = new HttpClient();
            var baseUrl = "http://localhost:61009/api/products/GetProductsSyncList";
            //var baseUrl = App.BackendUrl + "/api/products/GetProductsSyncList";
            try
            {
                string client = "TAM01";
                
                var uri = new Uri(baseUrl + $"?client={client}");
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var itemsList = JsonConvert.DeserializeObject<List<Product>>(jsonContent);
                    return itemsList;

                }
                else
                {
                    var e = new Exception(response.ToString());
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // return null;
                throw e;
            }
        }
    }
}
