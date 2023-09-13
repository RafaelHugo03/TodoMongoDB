using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class Todo
    {
        public string TaskName { get; set; }
        public bool Done { get; set; }


        public Entities.Todo ToModel(){
            return new Entities.Todo
            {
                TaskName = this.TaskName,
                Done = this.Done,
                CreateAt = DateTime.Now,
                DoneAt = this.Done == true ? DateTime.Now : null,
            };
        }
    }
}