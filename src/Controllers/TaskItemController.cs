using Application.Commands.AddTaskItem;
using Application.Queries.GetAllTasks;
using DAL;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskMgmtAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/GetAllTasks")]
        public async Task<IEnumerable<TaskItem>> Get()
        {
            return await _mediator.Send(new GetAllTasksQuery { });
        }
        [HttpPost]
        [Route("/CreateTask")]
        public async Task<IEnumerable<TaskItem>> Post(AddTaskItemCommand cmd)
        {
            return await _mediator.Send(cmd);

        }
        //[HttpPut]
        //[Route("/CompleteTask")]
        //public async Task<IActionResult> CompleteTask(int Id)
        //{
        //    var result = await _taskItemRepository.CompleteTaskAsync(Convert.ToInt32(Id));
        //    if (result > 0)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }
        //}

        //[HttpDelete]
        //[Route("/DeleteTask")]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var result = await _taskItemRepository.DeleteTaskAsync(Id);
        //    if (result > 0)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }
        //}

    }
}
