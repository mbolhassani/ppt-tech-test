using System.Net.Http.Headers;
using Api.Models;

namespace Api.Requests
{
    public class JSONServerRequest : IJSONServerRequest
    {
        public async Task<Image> GetImageByLastDigitOfUserIdentifierAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://my-json-server.typicode.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"ck-pacificdev/tech-test/images/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var image = await response.Content.ReadFromJsonAsync<Image>();
                    if (image == null)
                    {
                        throw new Exception("Image Not Found.");
                    }
                    else
                    {
                        return image;
                    }
                    //var BS = JsonConvert.DeserializeObject<dynamic>(data);
                    //Console.WriteLine(responseData?.Url);
                    //serviceResponse.Data = responseData?.Url;
                }
                throw new Exception("Wasn't able to retrieve the imge from json server.");

            }
        }
    }
}