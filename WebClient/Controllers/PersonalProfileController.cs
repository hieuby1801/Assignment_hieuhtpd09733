using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClient.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebClient.Controllers
{
    public class PersonalProfileController : Controller
    {
        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
            "eyJleHAiOjE3MjkzMjc0MTIsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyMDciLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MjA3In0." +
            "pNGlZVX56gICfu57s0dDhFmP5J9Kfs5IYAYP3WWyiuU";
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
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
