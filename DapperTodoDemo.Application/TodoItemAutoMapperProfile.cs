using AutoMapper;
using DapperTodoDemo.Domain;

namespace DapperTodoDemo.Application
{
    public class TodoItemAutoMapperProfile : Profile
    {
        public TodoItemAutoMapperProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();

            CreateMap<CreateUpdateTodoItemDto, TodoItem>();
        }
    }
}