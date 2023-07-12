using CPKPBL;
using CPKPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPKPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IBL _BL;
        private readonly IConfiguration _configuration;

        public MainController(IBL bL, IConfiguration configuration)
        {
            _BL = bL;
            _configuration = configuration;
        }
       

        [HttpGet("getPlayerStats/{p_playerid}")]
        public async Task<IActionResult> GetPlayerStats(int p_playerid)
        {
            return Ok(await _BL.GetPlayerStats(p_playerid));
        }

        [HttpPut("updatePlayerStats")]
        public async Task<IActionResult> UpdatePlayerStats([FromBody] StatDTO p_stat)
        {
            return Ok(await _BL.UpdatePlayerStats(p_stat));
        }

        [HttpPut("updatePlayer")]
        public async Task<IActionResult> UpdatePlayer([FromBody] PlayerDTO p_player)
        {
            return Ok(await _BL.UpdatePlayer(p_player));
        }
        [HttpPost("createPlayer")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerDTO p_player)
        {
            return Created("api/Main/createPlayer", await _BL.CreatePlayer(p_player));
        }
        [HttpGet("testVal")]
        public async Task<IActionResult> TestVal(int pval)
        {

            return Ok(await _BL.TestVal(pval));
        }


        


    }
}
