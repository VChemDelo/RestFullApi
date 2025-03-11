using Dapper;
using Npgsql;
using RestFullApi.Interfaces;
using RestFullApi.Models;

namespace RestFullApi.Repositories
{
    public class BotTokenRepository : IBotTokenRepository
    {
        private readonly string _connectionString;

        public BotTokenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<BotToken> GetToken(string key)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<BotToken>("SELECT value FROM public.sysbottoken WHERE key = @key", new { key = key });
            }
        }
    }
}
