using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalProfileController : Controller
    {
        private readonly IPersonalProfileService _profileRepository;
        private readonly IMapper _mapper;
        public PersonalProfileController (IPersonalProfileService profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(PersonalProfileDto profileDto)
        {
            if (profileDto == null)
                return BadRequest(ModelState); // BadRequest produce 400 BadRequest Respones
                                               // Model state represents errors that come from two subsystems: model binding and model validation
            var checkPhone = _profileRepository.ExistPhone(profileDto.Phone);
            var checkEmail = _profileRepository.ExistEmail(profileDto.Email);
            // Tìm xem có trùng phone or email nào trong csdl không

            if (checkPhone)
            {
                ModelState.AddModelError("", "Phone already exists");
                return StatusCode(422, ModelState);
            } // Nếu đã có phone này trong csdl thì trả về lỗi
            if (checkEmail)
            {
                ModelState.AddModelError("", "Email already exists");
                return StatusCode(422, ModelState);
            } // Nếu đã có email này trong csdl thì trả về lỗi

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // ModelState.IsValid (is valid: có hiệu lực)
            // chỉ ra liệu có thể liên kết các giá trị đầu vào từ yêu cầu tới Model một cách chính xác hay không
            // và liệu có bất kỳ quy tắc xác thực nào được chỉ định rõ ràng bị phá vỡ trong quá trình liên kết mô hình hay không.
            // ko rõ lắm, maybe dữ liệu có đúng chuẩn hay không

            var profileMap = _mapper.Map<PersonalProfile>(profileDto);// map Dto về Entity 

            if (!_profileRepository.CreateProfile(profileMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            } // trả lỗi khi service ko thể add Profile vào database

            return Ok("Successfully created");
        }
    }
}
