using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebAPI.DTOs;
using WebAPI.Interface;
using WebAPI.AutoMapper;
using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        private readonly IMapper _mapper;
        public AccountController(IAccountService account, IMapper mapper)
        {
            _account = account;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(AccountDto accountDto)
        {
            if (accountDto == null)
                return BadRequest(ModelState); // BadRequest produce 400 BadRequest Respones
                                               // Model state represents errors that come from two subsystems: model binding and model validation
            var account = _account.GetAccounts()
                .Where(c => c.UserName.Trim().ToUpper() == accountDto.UserName.TrimEnd().ToUpper())
                .FirstOrDefault(); // Tìm xem có trùng username nào trong csdl không

            if (account != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            } // Nếu đã có username này trong csdl thì trả về lỗi

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // ModelState.IsValid chỉ ra liệu có thể liên kết các giá trị đầu vào từ yêu cầu tới Model một cách chính xác hay không
            // và liệu có bất kỳ quy tắc xác thực nào được chỉ định rõ ràng bị phá vỡ trong quá trình liên kết mô hình hay không.
            // ko rõ lắm, maybe dữ liệu có đúng chuẩn hay không

            var accountMap = _mapper.Map<Account>(accountDto);// map Dto về Entity 

            if (!_account.CreateAccount(accountMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            } // trả lỗi khi service ko thể add Account vào database

            return Ok("Successfully created");
        }
    }
}
