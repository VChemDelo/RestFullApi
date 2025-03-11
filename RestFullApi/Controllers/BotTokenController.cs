using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFullApi.Models;
using RestFullApi.Services;

namespace RestFullApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotTokenController : ControllerBase
    {
        private readonly BotTokenService _botTokenService;

        public BotTokenController(BotTokenService botTokenService)
        {
            _botTokenService = botTokenService;
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<BotToken>> GetToken(string key)
        {
            var bottoken = await _botTokenService.GetToken(key);
            if (bottoken == null) return NotFound();
            return Ok(bottoken);
        }
    }
}
