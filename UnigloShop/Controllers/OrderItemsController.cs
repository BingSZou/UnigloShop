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
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IUnigloRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsController(IUnigloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<OrderItemViewModel>> GetOrderItems(int orderid)
        {
            var msg = "Get Order Items failed.";
            try
            {
                var order = _repository.GetOrderById(orderid);
                if(order != null)
                {
                    return Ok(_mapper.Map<ICollection<OrderItem>, ICollection<OrderItemViewModel>>(order.Items));
                }
                else
                {
                    return NotFound($"The Order for specified id {orderid} not found.");
                }
            }catch(Exception ex)
            {
                return BadRequest(msg);
            }
        }

        [HttpGet("{orderitemid}")]
        public ActionResult<OrderItemViewModel> GetOrderItemById(int orderid, int orderitemid)
        {
            try
            {
                var order = _repository.GetOrderById(orderid);
                if (order != null)
                {
                    var orderItem = order.Items.FirstOrDefault(oi => oi.Id == orderitemid);
                    return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(orderItem));
                }
                else
                {
                    return NotFound($"The Order item for specified id {orderid} and {orderitemid} not found.");
                }

            }
            catch(Exception ex)
            {
                return BadRequest($"The request for Order item for specified id {orderid} and {orderitemid} failed.");
            }
        }
    }
}
