
using MongoDB.Driver;
using Todo.Data;

namespace Todo.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly Contexto contexto;

        public TodoRepository(IConfiguration configuration)
        {
            contexto = new Contexto(configuration);
        }

        public void Create(Entities.Todo todo)
        {
            var oldTodo = GetAll().OrderBy(s => s.Id).LastOrDefault();
            todo.Id = oldTodo != null ? oldTodo.Id + 1 : 1;
            contexto.Todos.InsertOne(todo);
        }

        public void Delete(int id)
        {
            contexto.Todos.DeleteOne(s => s.Id == id);
        }

        public List<Entities.Todo> GetAll()
        {
            return contexto.Todos.Find(s => true).ToList();
        }

        public Entities.Todo GetById(int id)
        {
            return contexto.Todos.Find(s => s.Id == id).FirstOrDefault();
        }

        public void Update(Entities.Todo todo)
        {
            contexto.Todos.ReplaceOne(s => s.Id == todo.Id, todo);
        }
    }
}