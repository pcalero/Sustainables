using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Supervisor;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IVendingSupervisor _vendingSupervisor;

        public ProductController(IVendingSupervisor vendingSupervisor)
        {
            _vendingSupervisor = vendingSupervisor;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductApiModel>>> GetAll()
        {
            try
            {
                return new ObjectResult(await _vendingSupervisor.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("buy/{id}")]
        public async Task<ActionResult<ServiceResponse<List<CoinApiModel>>>> BuyProduct([FromRoute] int id, List<CoinApiModel> depositedCoins)
        {
            
            try
            {
                return await _vendingSupervisor.BuyProduct(id, depositedCoins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
