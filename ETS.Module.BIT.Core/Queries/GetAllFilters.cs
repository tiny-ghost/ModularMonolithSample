using Ericsson.ETS.Core.Models;
using ETS.Module.BIT.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ETS.Module.BIT.Core.Queries
{
    public class GetAllFilters : IRequest<IEnumerable<Filter>>
    {
    }
    internal class FilterQueryHandler : IRequestHandler<GetAllFilters, IEnumerable<Filter>>
    {
        private readonly IBitDbContext _context;

        public FilterQueryHandler(IBitDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Filter>> Handle(GetAllFilters request, CancellationToken cancellationToken)
        {
            var filters = await _context.Filters.OrderBy(x => x.Id).ToListAsync(cancellationToken);

            return filters ?? throw new Exception("Filters are not found");
        }
    }
}
