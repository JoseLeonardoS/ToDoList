namespace ToDoList.Dto
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool TaskDone { get; set; } = false;
    }
}
