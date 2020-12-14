using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [Route("/api/products")]
   // [Produces("appplication/json")]
    public class ProductsController :ControllerBase
    {
        private readonly IUnigloRepository _repository;
     //   private readonly ILogger _logger;

        public ProductsController(IUnigloRepository repository)//, ILogger logger)
        {
            _repository = repository;
      //      _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var ps = _repository.GetAllProducts();
                var output = new List<Product>();
                foreach(var p in ps)
                {
                    output.Add(new Product());
                }
                return Ok(_repository.GetAllProducts());
                //return output;

            }catch(Exception ex)
            {
                var msg = "Failed to get products";
      //          _logger.LogError($"{msg}: {ex}");
                return BadRequest(msg) ;
            }
        }
/*
        [HttpPost]
        public IActionResult Create(ProductViewModel productVm)
        {
            return CreatedResult();
        }*/



    }
}
