using System.Collections.Generic;
using DapperTodoDemo.Application;

namespace DapperTodoDemo.Web.Models
{
    public class TodoViewModel
    {
        public List<TodoItemDto> TodoItems { get; set; }
    }
}