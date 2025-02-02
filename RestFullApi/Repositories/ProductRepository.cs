using Dapper;
using Npgsql;
using RestFullApi.Interfaces;
using RestFullApi.Models;
using System.Collections;

namespace RestFullApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Product>("SELECT * FROM public.Products");
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM public.Products WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddProductAsync(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "INSERT INTO public.Products (id,name, price) VALUES (@Id, @Name, @Price)";

                await connection.ExecuteAsync(sql, product);
            }
        }
    }
}
