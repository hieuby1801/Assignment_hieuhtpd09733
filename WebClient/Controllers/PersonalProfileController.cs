using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClient.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Net.Http;

namespace WebClient.Controllers
{
    public class PersonalProfileController : Controller
    {
        //private readonly HttpClient _httpClient;

        //public PersonalProfileController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClient = httpClientFactory.CreateClient("ProfileAPI");
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonalProfile profile)
        {

            var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
            using (var _httpClient = new HttpClient())
            {
                using (var response = await _httpClient.PostAsync("https://localhost:7207/api/personalprofile", content))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(profile);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profiles = new List<PersonalProfile>();
            using (var _httpClient = new HttpClient())
            {
                using (var response = await _httpClient.GetAsync("https://localhost:7207/api/PersonalProfile"))
                {  // Giả sử API trả về danh sách các profile
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        profiles = JsonConvert.DeserializeObject<List<PersonalProfile>>(content);

                    }
                }
            }
            return View(profiles);
        }
        public async Task<IActionResult> GetProductByName()
        {
            using (var _httpClient = new HttpClient())
            {
                var profiles = new List<PersonalProfile>();

                using (var response = await _httpClient.GetAsync("https://localhost:7207/api/PersonalProfile/search/son"))
                {  // Giả sử API trả về danh sách các profile
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        profiles = JsonConvert.DeserializeObject<List<PersonalProfile>>(content);
                    }
                }
                return View(profiles);  
            }
        }

    }
}
