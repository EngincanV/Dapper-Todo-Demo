using System;
using System.Threading.Tasks;
using DapperTodoDemo.Application;
using DapperTodoDemo.Domain;
using DapperTodoDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTodoDemo.Web.Areas.DapperTodoDemo.Controllers
{
    [Area("TodoItem")]
    [Route("TodoItem")]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemAppService _todoItemAppService;

        public TodoItemController(ITodoItemAppService todoItemAppService)
        {
            _todoItemAppService = todoItemAppService;
        }

        [HttpPost("create")]
        public async Task<PartialViewResult> CreateAsync(string title, string description)
        {
            await _todoItemAppService.CreateAsync(new CreateUpdateTodoItemDto { Title = title, Description = description });
            var todoItems = await _todoItemAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

        [HttpPut("update")]
        public async Task<PartialViewResult> UpdateAsync(Guid id, string title, string description, bool status)
        {
            await _todoItemAppService.UpdateAsync(id, new CreateUpdateTodoItemDto { Title = title, Description = description, Status = !status ? TodoStatus.Opened : TodoStatus.Closed });
            var todoItems = await _todoItemAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

        [HttpDelete("delete")]
        public async Task<PartialViewResult> DeleteAsync([FromQuery]Guid id)
        {
            await _todoItemAppService.DeleteAsync(id);
            var todoItems = await _todoItemAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

    }
}