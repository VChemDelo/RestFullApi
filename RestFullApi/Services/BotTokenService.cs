using RestFullApi.Interfaces;
using RestFullApi.Models;
using RestFullApi.Repositories;

namespace RestFullApi.Services
{
    public class BotTokenService
    {
        private readonly IBotTokenRepository _botTokenRepository;

        public BotTokenService (IBotTokenRepository botTokenRepository)
        {
            _botTokenRepository = botTokenRepository;
        }

        public async Task<BotToken> GetToken(string key)
        {
            return await _botTokenRepository.GetToken(key);
        }
    }
}
