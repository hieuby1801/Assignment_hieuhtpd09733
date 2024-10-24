using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(OrderDto orderDto)
        {
            if (orderDto == null)
                return BadRequest(ModelState); 
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var orderMap = _mapper.Map<Order>(orderDto);

            if (!_orderService.CreateOrder(orderMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            } 

            return Ok("Successfully created");
        }

        [HttpGet("{accId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderByAccId(int accId)
        {
            Order orderExist = _orderService.GetOrderUncomplete(accId);
            if (orderExist == null)
            {
                OrderDto orderDto= new OrderDto() { AccountId = accId, OrderStatus = 0};
                var newOrder = _mapper.Map<Order>(orderDto);
                _orderService.CreateOrder(newOrder);
                return Ok(newOrder);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orderExist);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {            
            if (_orderService.UpdateOrder(order))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
