using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private IConfiguration _configuration { get; set; }
        public string _connectionString { get; set; }

        public TaskItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<TaskItem>("SELECT * FROM TaskItems");
        }

        public async Task<TaskItem> AddTaskItemAsync(TaskItem taskItem)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            await db.ExecuteScalarAsync(
               "INSERT INTO TaskItems (Title, Description, Status, CreatedAt) VALUES (@Title, @Description, @Status, @CreatedAt)",
               taskItem);
            return taskItem;
        }
        public async Task<int> DeleteTaskAsync(int Id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = await db.ExecuteAsync("delete TaskItems where Id=@Id", new { Id = Id });
            return result;

        }
        public async Task<int> CompleteTaskAsync(int Id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = await db.ExecuteAsync("update TaskItems set CompletedAt=@CompletedAt , status=@status where Id=@Id", new { CompletedAt = DateTime.UtcNow, status = "Complete", Id = Id });
            return result;
        }
    }
}
