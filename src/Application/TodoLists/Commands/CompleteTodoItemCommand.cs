using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Commands
{
    public record CompleteTodoItemCommand(int ListId, int itemId) : IRequest<int>;

    public class CompleteTodoItemCommandHandler : IRequestHandler<CompleteTodoItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CompleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CompleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var list = _context.TodoLists.Include(i => i.Items).FirstOrDefault(i => i.Id == request.ListId);

            if (list == null)
                throw new NullReferenceException("Invalid request");

            var item = list.Items.SingleOrDefault(i => i.Id == request.itemId);
            
            item?.MarkComplete();

            await _context.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
