using DAL;
using MediatR;

namespace Application.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<IEnumerable<TaskItem>>
    {
    }
}
