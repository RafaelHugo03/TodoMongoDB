namespace Todo.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool Done { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? DoneAt { get; set; }
    }
}