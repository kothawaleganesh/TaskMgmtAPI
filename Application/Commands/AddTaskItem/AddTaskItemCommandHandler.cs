using DAL;
using DAL.Repositories;
using MediatR;

namespace Application.Commands.AddTaskItem
{
    public class AddTaskItemCommandHandler : IRequestHandler<AddTaskItemCommand, TaskItem>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public AddTaskItemCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItem> Handle(AddTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Status = request.Status,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _taskItemRepository.AddTaskItemAsync(taskItem);
            return taskItem;
        }
    }
}
