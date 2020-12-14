using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Domain.Entities;
using Dapper;
using Domain.Contracts.Services;
using System.Net.Http;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _ProductsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _ProductsService = productsService;
        }


        [HttpGet]
        [Route("All")]
        public IEnumerable<Product> All()
        {
            try
            {
                List<Product> p = _ProductsService.Get();
                return p;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpGet]
        [Route("Find")]
        public Product Find(int ProductID)
        {
            try
            {
                Product p = _ProductsService.Get(ProductID);
                return p;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        [Route("Create")]
        public Product Create([FromBody] Product p)
        {
            try
            {
                Product res = _ProductsService.Create(p);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public Product Update([FromBody] Product p)
        {
            try
            {
                Product res = _ProductsService.Update(p);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public int Delete(int ProductID)
        {
            try
            {
                int res = _ProductsService.Delete(ProductID);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
