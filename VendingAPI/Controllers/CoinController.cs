using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Supervisor;

namespace VendingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinController : ControllerBase
    {
        private readonly IVendingSupervisor _vendingSupervisor;

        public CoinController(IVendingSupervisor vendingSupervisor)
        {
            _vendingSupervisor = vendingSupervisor;
        }

        [HttpGet]
        public async Task<ActionResult<List<CoinApiModel>>> GetAll()
        {
            try
            {
                return new ObjectResult(await _vendingSupervisor.GetAllCoins());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }

}
