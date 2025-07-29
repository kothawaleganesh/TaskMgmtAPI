using DAL;
using MediatR;

namespace Application.Commands.AddTaskItem
{
    public class AddTaskItemCommand :IRequest<TaskItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
