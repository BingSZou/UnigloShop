using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data;
using UnigloShop.Data.Entities;
using UnigloShop.ViewModel;

namespace UnigloShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnigloRepository _repository;

        public OrdersController(IUnigloRepository repository,
                        IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(_repository.GetAllOrders()) );
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to get orders {ex}");
                // log the error
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderViewModel> GetOrder(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);

                if (order != null)
                {
                    return Ok(_mapper.Map<Order, OrderViewModel>(order));
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to get order for {id} with error {ex}");
                return BadRequest($"Failed to get order for {id} with error {ex}");
            }
        }

        [HttpPost]
        public ActionResult<OrderViewModel> Post([FromBody] OrderViewModel orderVm)
        {
            var msg = "Failed to save a new order";
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModel, Order>(orderVm);
                    if(newOrder.OrderDate == DateTime.MinValue )
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _repository.AddOrder(newOrder);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", newOrder);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{msg}, {ex}");
                return BadRequest($"{msg}. {ex}");
            }

            return BadRequest($"{msg}.");
        }
    }
}
