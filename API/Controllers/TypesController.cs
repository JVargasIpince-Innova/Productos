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
    public class TypesController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ITypesService _TypesService;

        public TypesController(ILogger<ProductsController> logger, ITypesService TypesService)
        {
            _logger = logger;
            _TypesService = TypesService;
        }


        [HttpGet]
        [Route("All")]
        public IEnumerable<Domain.Entities.Type> All()
        {
            try
            {
                List<Domain.Entities.Type> p = _TypesService.Get();
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
        public Domain.Entities.Type Find(int TypeID)
        {
            try
            {
                Domain.Entities.Type p = _TypesService.Get(TypeID);
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
        public int Create([FromBody] Domain.Entities.Type p)
        {
            try
            {
                int res = _TypesService.Create(p);
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
        public Domain.Entities.Type Update([FromBody] Domain.Entities.Type p)
        {
            try
            {
                Domain.Entities.Type res = _TypesService.Update(p);
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
        public int Delete(int TypeID)
        {
            try
            {
                int res = _TypesService.Delete(TypeID);
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
