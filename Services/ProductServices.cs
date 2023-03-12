using ApiCaching.Abstract;
using ApiCaching.Models;
using Newtonsoft.Json;

namespace ApiCaching.Services
{
    public class ProductServices : IProductServices
    {
        private readonly string consume = "https://dummyjson.com/products";
        public async Task<IList<Product>> GetProducts()
        {
            using (var client = new HttpClient())
            {
                // Send a GET request to the API
                HttpResponseMessage response = await client.GetAsync(consume);

                // Check the status code of the response
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var data = JsonConvert.DeserializeObject<ProductResponse>(responseString);
                        return data.Products;
                    }
                }
            }
            return null;
        }
    }
}
