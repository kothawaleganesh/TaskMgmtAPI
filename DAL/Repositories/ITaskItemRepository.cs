namespace DAL.Repositories
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> AddTaskItemAsync(TaskItem taskItem);
        Task<int> DeleteTaskAsync(int Id);
        Task<int> CompleteTaskAsync(int Id);
    }
}
