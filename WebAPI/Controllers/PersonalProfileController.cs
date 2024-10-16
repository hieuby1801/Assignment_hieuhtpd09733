using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonalProfile>))]
        public IActionResult GetPersonalProfiles()
        {
            var profiles = _mapper.Map<List<PersonalProfileDto>>(_profileRepository.GetPersonalProfiles());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(profiles);
        }

        [HttpGet, Route("search/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonalProfile>))]
        [ProducesResponseType(400)]
        public IActionResult SearchPersonalProfiles(string name)
        {
            var profiles = _mapper.Map<List<PersonalProfileDto>>(_profileRepository.GetPersonalProfiles(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(profiles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonalProfile))]
        [ProducesResponseType(400)]
        public IActionResult GetPersonalProfile(int id)
        {
            if (!_profileRepository.ExistProfile(id))
                return NotFound();

            var profile = _mapper.Map<PersonalProfile>(_profileRepository.GetPersonalProfile(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(profile);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(PersonalProfileDto profileDto)
        {
            if (profileDto == null)
                return BadRequest(ModelState); // BadRequest produce 400 BadRequest Respones
                                               // Model state represents errors that come from two subsystems: model binding and model validation
            bool checkPhone = _profileRepository.ExistPhone(profileDto.Phone);
            bool checkEmail = _profileRepository.ExistEmail(profileDto.Email);
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

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProfile(int id, [FromBody]PersonalProfileDto profile)
        {
            if(profile == null)
                return BadRequest(ModelState) ;

            if(id != profile.Id)
                return BadRequest(ModelState);

            if(!_profileRepository.ExistProfile(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var profileMap = _mapper.Map<PersonalProfile>(profile);

            if (!_profileRepository.UpdateProfile(profileMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Profile");
                return StatusCode(500, ModelState) ;
            }

            return NoContent();
        }
    }
}
