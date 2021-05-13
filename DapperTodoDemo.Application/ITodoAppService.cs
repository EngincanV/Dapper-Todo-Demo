using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTodoDemo.Domain;

namespace DapperTodoDemo.Application
{
    public interface ITodoAppService
    {
        Task<List<TodoItemDto>> GetTodosAsync();

        Task<TodoItemDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateTodoItemDto todoItem);

        Task UpdateAsync(Guid id, CreateUpdateTodoItemDto todoItem);

        Task DeleteAsync(Guid id);
    }
}