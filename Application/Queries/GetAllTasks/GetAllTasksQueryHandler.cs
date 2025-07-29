using DAL;
using DAL.Repositories;
using MediatR;

namespace Application.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public GetAllTasksQueryHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskItemRepository.GetAllTasksAsync();
        }
    }
}
