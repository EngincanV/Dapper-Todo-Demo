using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperTodoDemo.Domain.Repository
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetListAsync();

        Task<TodoItem> GetAsync(Guid id);

        Task<TodoItem> InsertAsync(TodoItem todoItem);

        Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem);

        Task DeleteAsync(Guid id);
    }
}