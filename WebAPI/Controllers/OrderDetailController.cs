using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderDetailMap = _mapper.Map<OrderDetail>(orderDetailDto);

            if (!_orderDetailService.CreateOrderDetail(orderDetailMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderDetails(int orderId)
        {
            return Ok(_orderDetailService.GetOrderDetails(orderId));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetail orderDetailDto)
        {
            var orderDetailMap = _mapper.Map<OrderDetail>(orderDetailDto);
            _orderDetailService.UpdateOrderDetail(orderDetailMap);
            return Ok();
        }
    }
}
