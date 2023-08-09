﻿using h_data.DataAccessInterfaces;
using h_data.Entities;
using m_business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace q_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDA _orderDA;
        private readonly IAnimalDA _animalDA;

        public OrderController(IOrderDA orderDA, IAnimalDA animalDA)
        {
            _orderDA = orderDA;
            _animalDA = animalDA;
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<OrderItem> items)
        {
            try
            {
                var orderBO = new OrderBO(_orderDA, _animalDA);
                var order = await orderBO.Create(items);
                return Ok(new
                {
                    Id = order.OrderId,
                    TotalAmount = order.NetPrice
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
