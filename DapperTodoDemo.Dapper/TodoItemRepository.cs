using System;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTodoDemo.Domain;
using DapperTodoDemo.Domain.Repository;

namespace DapperTodoDemo.Dapper
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly string _connectionString = "Server=localhost;Database=DapperTodoDemo;Trusted_Connection=true";
        
        public Task<List<TodoItem>> GetListAsync()
        {
            using var connection = new Dapper.TodoItemRepository().
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> InsertAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}