using Microsoft.AspNetCore.Mvc;
using Todo.Repository;

namespace Todo.Controllers
{
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(todoRepository.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(todoRepository.GetById(id));
        }

        [HttpPost("Create")]
        public IActionResult Post([FromBody] Models.Todo todo)
        {
            var entity = todo.ToModel();
            todoRepository.Create(entity);
            return Ok(entity);
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromBody] Models.UpdateTodo dto)
        {
            var entity = dto.Todo.ToModel();
            entity.Id = dto.Id;
            todoRepository.Update(entity);
            return Ok(entity);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            todoRepository.Delete(id);
            return Ok();
        }
    }
}