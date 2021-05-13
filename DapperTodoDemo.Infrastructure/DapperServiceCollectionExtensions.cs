using DapperTodoDemo.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DapperTodoDemo.Infrastructure
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();

            return services;
        }
    }
}