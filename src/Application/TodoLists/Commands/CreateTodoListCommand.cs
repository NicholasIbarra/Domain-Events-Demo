using Application.Common.Interfaces;
using Domain.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Commands
{
    public record CreateTodoListCommand(string? Name) : IRequest<int>;

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList();

            entity.Name = request.Name;

            _context.TodoLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
