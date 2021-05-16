using Autofac;
using DapperTodoDemo.Application;
using DapperTodoDemo.Domain.Repository;
using DapperTodoDemo.Infrastructure;

namespace DapperTodoDemo.Web
{
    public class DapperTodoDemoApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TodoItemRepository>().As<ITodoItemRepository>(); //TODO: it must not depend on infrastructure layer?
            builder.RegisterType<TodoItemAppService>().As<ITodoItemAppService>();
        }
    }
}