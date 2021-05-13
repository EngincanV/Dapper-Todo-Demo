using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTodoDemo.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DapperTodoDemo.Web.Pages
{
    public class Todos : PageModel
    {
        public List<TodoItemDto> TodoItems { get; set; }
        
        private readonly ITodoAppService _todoAppService;

        public Todos(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        public async Task OnGetAsync()
        {
            TodoItems = await _todoAppService.GetTodosAsync();
        }
    }
}