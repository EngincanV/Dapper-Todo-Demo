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
        private readonly ITodoAppService _todoAppService;

        public TodoItemController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpPost("create")]
        public async Task<PartialViewResult> CreateAsync(string title, string description)
        {
            await _todoAppService.CreateAsync(new CreateUpdateTodoItemDto { Title = title, Description = description, Status = TodoStatus.Opened});
            var todoItems = await _todoAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

        [HttpPost("update")]
        public async Task<PartialViewResult> UpdateAsync(Guid id, string title, string description, bool status)
        {
            await _todoAppService.UpdateAsync(id, new CreateUpdateTodoItemDto { Title = title, Description = description, Status = status ? TodoStatus.Opened : TodoStatus.Closed });
            var todoItems = await _todoAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

        [HttpPost("delete")]
        public async Task<PartialViewResult> DeleteAsync(Guid id)
        {
            await _todoAppService.DeleteAsync(id);
            var todoItems = await _todoAppService.GetTodosAsync();
            
            return PartialView("~/Pages/_Todo.cshtml", new TodoViewModel { TodoItems = todoItems });
        }

    }
}