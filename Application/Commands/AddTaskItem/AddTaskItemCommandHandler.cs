using Application.Queries.GetAllTasks;
using DAL;
using DAL.Repositories;
using MediatR;

namespace Application.Commands.AddTaskItem
{
    public class AddTaskItemCommandHandler : IRequestHandler<AddTaskItemCommand, IEnumerable<TaskItem>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMediator _mediator;

        public AddTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IMediator mediator)
        {
            _taskItemRepository = taskItemRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TaskItem>> Handle(AddTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Status = request.Status,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _taskItemRepository.AddTaskItemAsync(taskItem);
            var items = await _mediator.Send(new GetAllTasksQuery { });
            return items;
        }
    }
}
