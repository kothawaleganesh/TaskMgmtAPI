using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL
{
    public class TaskItemService
    {
        private IConfiguration _configuration { get; set; }
        public string _connectionString { get; set; }

        public TaskItemService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<TaskItem>("SELECT * FROM TaskItems");
        }

    }
}
