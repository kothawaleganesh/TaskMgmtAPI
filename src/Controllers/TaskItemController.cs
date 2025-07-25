using DAL;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskMgmtAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private IConfiguration _configuration { get; set; }
        public string _connectionString { get; set; }
        public TaskItemController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        [Route("/GetAllTasks")]
        public async Task<IActionResult> Get()
        {
            var taskService = new TaskItemService(_configuration);
            var tasks = await taskService.GetAllTasksAsync();
            return Ok(tasks);

        }
        [HttpPost]
        [Route("/CreateTask")]
        public async Task<IActionResult> Post(TaskItem task)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            await db.ExecuteAsync( //
               "INSERT INTO TaskItems (Title, Description, Status, CreatedAt) VALUES (@Title, @Description, @Status, @CreatedAt)",
               task);

            return Ok(task);
        }
        [HttpPut]
        [Route("/CompleteTask")]
        public async Task<IActionResult> CompleteTask(string Id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = await db.ExecuteAsync("update TaskItems set CompletedAt=@CompletedAt , status=@status where Id=@Id", new { CompletedAt = DateTime.UtcNow, status = "Complete", Id = Id });
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("/DeleteTask")]
        public async Task<IActionResult> Delete(string Id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = await db.ExecuteAsync("delete TaskItems where Id=@Id", new { Id = Id });
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
