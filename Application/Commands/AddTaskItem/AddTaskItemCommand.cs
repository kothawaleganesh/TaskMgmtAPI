using DAL;
using MediatR;

namespace Application.Commands.AddTaskItem
{
    public class AddTaskItemCommand :IRequest<IEnumerable<TaskItem>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
