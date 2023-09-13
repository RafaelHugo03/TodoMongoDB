namespace Todo.Repository
{
    public interface ITodoRepository
    {
        List<Entities.Todo> GetAll();
        Entities.Todo GetById(int id);
        void Create(Entities.Todo todo);
        void Update(Entities.Todo todo);
        void Delete(int id);
    }
}