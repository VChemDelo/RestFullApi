using RestFullApi.Models;

namespace RestFullApi.Interfaces
{
    public interface IBotTokenRepository
    {
        Task<BotToken> GetToken(string key);
    }
}
