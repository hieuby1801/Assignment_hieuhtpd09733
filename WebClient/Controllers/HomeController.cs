using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Packaging.Signing;
using System.Net.Http.Headers;
using System.Text;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public string token;
        public int AccID;

        public HomeController()
        {
            _httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.BaseAddress = new Uri("https://localhost:7207/api/");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foods = new List<Food>();
            using (var response = await _httpClient.GetAsync("Food"))
            {  // Giả sử API trả về danh sách các profile
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    foods = JsonConvert.DeserializeObject<List<Food>>(content);
                }
            }
            return View(foods);
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(WebClient.Models.LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequest); 
            }

            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync("Account/login", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var respone = await response.Content.ReadAsStringAsync();
                    WebClient.Models.LoginRequest data_respone = JsonConvert.DeserializeObject<WebClient.Models.LoginRequest>(respone);
                    SessionInfo.accId = (int)data_respone.Id; // SessionInfo là static class
                    return RedirectToAction("OrderFood");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Thông tin không chính xác. Vui lòng thử lại.");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrderFood()
        {
            var foods = new List<Food>();
            using (var response = await _httpClient.GetAsync("Food"))
            {  // Giả sử API trả về danh sách các profile
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    foods = JsonConvert.DeserializeObject<List<Food>>(content);
                }
            }
            return View(foods);
        }
        //[HttpGet]
        //public async Task<IActionResult> AddToCart(int accId,int FoodId)
        //{
        //    int orderId;
        //    var listDetail = new List<OrderDetail>();
        //    // gọi api get(accID) CreateOrder(int accID) kiểm tra tồn tại order với status=0, chưa thì tạo, trả về order này
        //    var responeOrder = await _httpClient.GetAsync($"Order/{accId}");
        //    var orderJson = await responeOrder.Content.ReadAsStringAsync();
        //    orderId = JsonConvert.DeserializeObject<Order>(orderJson).Id;
        //    var responeOrderDetails = await _httpClient.GetAsync($"OrderDetail/{orderId}");
        //    var detailJson = await responeOrder.Content.ReadAsStringAsync();
        //    listDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(detailJson);

        //    var orderDetailExist = listDetail.Where(ld => ld.FoodId == FoodId).FirstOrDefault();
        //    if (orderDetailExist == null)
        //    {
        //        OrderDetail newOrderDetail = new OrderDetail() { OrderId = orderId, FoodId = FoodId, QuantityFood = 1 };
        //        var contentOD = new StringContent(JsonConvert.SerializeObject(newOrderDetail), Encoding.UTF8, "application/json");
        //        var responseNewOD = await _httpClient.PostAsync("OrderDetail", contentOD);
        //        listDetail.Add(newOrderDetail);
        //        return View(listDetail);                
        //    }
        //    orderDetailExist.QuantityFood += 1;
        //    listDetail.Add(orderDetailExist);
                        
        //    return View(listDetail);
        //}
        //using (var responeOrder = await _httpClient.GetAsync($"Order/{accId}"))
        //{
        //    if (responeOrder.IsSuccessStatusCode)
        //    {
        //        var orderJson = await responeOrder.Content.ReadAsStringAsync();
        //        orderId = JsonConvert.DeserializeObject<Order>(orderJson).Id;

        //        // goi api post(orderID, foodId) kiểm tra tồn tại foodId trong orderId hay ko, có thì +1 sp, ko thì tạo,
        //        // (có thể thay đổi sl qua edit và xoá qua delete - này thì qua view gắn controller của OrderDetail dô)            
        //        using (var responeOrderDetails = await _httpClient.GetAsync($"OrderDetail/{orderId}"))
        //        {
        //            if (responeOrderDetails.IsSuccessStatusCode)
        //            {
        //                var detailJson = await responeOrder.Content.ReadAsStringAsync();
        //                listDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(detailJson);

        //                var orderDetailExist = listDetail.Where(ld => ld.FoodId == FoodId).FirstOrDefault();
        //                if (orderDetailExist == null)
        //                {
        //                    OrderDetail newOrderDetail = new OrderDetail() { OrderId = orderId, FoodId = FoodId, QuantityFood = 1 };
        //                    var contentOD = new StringContent(JsonConvert.SerializeObject(newOrderDetail), Encoding.UTF8, "application/json");

        //                    using (var responseNewOD = await _httpClient.PostAsync("OrderDetail", contentOD))
        //                    {
        //                        if (responseNewOD.IsSuccessStatusCode)
        //                        {
        //                            listDetail.Add(newOrderDetail);
        //                            return View(listDetail);
        //                        }
        //                        else
        //                        {
        //                            ModelState.AddModelError(string.Empty, "Thông tin không chính xác. Vui lòng thử lại.");
        //                        }
        //                    }
        //                }
        //                orderDetailExist.QuantityFood += 1;
        //                listDetail.Add(orderDetailExist);
        //            }
        //        }
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> AddToCart(int accId, int FoodId)
        {
            
            var listDetail = new List<OrderDetail>();

            // Gọi API để kiểm tra và lấy order với accId
            var responseOrder = await _httpClient.GetAsync($"Order/{accId}");
            var orderJson = await responseOrder.Content.ReadAsStringAsync();
            SessionInfo.orderId = JsonConvert.DeserializeObject<Order>(orderJson).Id;
            int orderId = SessionInfo.orderId;

            // Gọi API để lấy danh sách OrderDetail của orderId
            var responseOrderDetails = await _httpClient.GetAsync($"OrderDetail/{orderId}");
            var detailJson = await responseOrderDetails.Content.ReadAsStringAsync();
            listDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(detailJson);

            // Kiểm tra xem món ăn đã có trong giỏ hàng hay chưa
            var orderDetailExist = listDetail.Where(ld => ld.FoodId == FoodId).FirstOrDefault();
            if (orderDetailExist == null)
            {
                // Nếu chưa có, tạo mới OrderDetail
                OrderDetail newOrderDetail = new OrderDetail() { OrderId = orderId, FoodId = FoodId, QuantityFood = 1 };
                var contentOD = new StringContent(JsonConvert.SerializeObject(newOrderDetail), Encoding.UTF8, "application/json");
                var responseNewOD = await _httpClient.PostAsync("OrderDetail", contentOD);
                listDetail.Add(newOrderDetail);
                return View(listDetail);
            }

            // Nếu đã tồn tại, cập nhật số lượng
            
            OrderDetail updateOrderDetail = new OrderDetail() { Id = orderDetailExist.Id, OrderId = orderId, FoodId = FoodId, QuantityFood = orderDetailExist.QuantityFood + 1 };
            var contentUpdateOD = new StringContent(JsonConvert.SerializeObject(updateOrderDetail), Encoding.UTF8, "application/json");
            var responseUpdateOD = await _httpClient.PutAsync($"OrderDetail", contentUpdateOD);
            listDetail.Where(ld => ld.FoodId == FoodId).FirstOrDefault().QuantityFood++;
            return View(listDetail);
        }

        //public async Task<IActionResult> AddToCart(List<OrderDetail> orderDetails)
        //{
        //    return View(orderDetails);
        //}
        public async Task<IActionResult> Buy(int orderId)
        {
            Order tempOrder = new Order() { Id = orderId, AccountId = SessionInfo.accId, OrderStatus = 1};
            var contentUpdateOrder = new StringContent(JsonConvert.SerializeObject(tempOrder), Encoding.UTF8, "application/json");
            var responseUpdateOrder = await _httpClient.PutAsync($"Order", contentUpdateOrder);
            return RedirectToAction("OrderFood");
        }
        public async Task<IActionResult> SignOut()
        {
            SessionInfo.accId = 0;
            SessionInfo.orderId = 0;
            return RedirectToAction("Index");
        }
    }
}
