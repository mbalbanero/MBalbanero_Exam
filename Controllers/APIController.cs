using MBalbanero_Exam.Models;
using MBalbanero_Exam.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBalbanero_Exam.Controllers
{
    [ApiController]
    [Route("api/get")]
    public class APIController : ControllerBase
    {
        private readonly IEthereumService _ethereumService;

        public APIController(IEthereumService ethereumService)
        {
            _ethereumService = ethereumService;
        }

        [HttpGet("{address}")]
        public async Task<ActionResult<EthereumInfo>> GetEthereumInfo(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return BadRequest("Address is required.");

            var result = await _ethereumService.GetEthereumInfoAsync(address);
            return Ok(result);
        }
    }
}
