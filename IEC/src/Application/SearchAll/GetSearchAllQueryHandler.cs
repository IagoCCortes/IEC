using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SearchAll
{
    public class GetSearchAllQueryHandler : IRequestHandler<GetSearchAllQuery, SearchAllVM>
    {
        private readonly IIECDbContext _context;

        public GetSearchAllQueryHandler(IIECDbContext context)
        {
            _context = context;
        }
        public async Task<SearchAllVM> Handle(GetSearchAllQuery request, CancellationToken cancellationToken)
        {            
            var result = new SearchAllVM();
            var dict = new Dictionary<string, List<SearchAllLookupDto>>();

            foreach (Type typeUsingISearchableEntity in GetTypesWithISearchableEntity())
            {
                
                var dtoResult = await _context.GetQuery<ISearchableEntity>(typeUsingISearchableEntity)
                .Where(x => x.StringIdentifier.ToLower().Contains(request.ValueToSearch.ToLower()))
                .Select(x => new SearchAllLookupDto {
                    Id = x.Id, 
                    MatchedValue = x.StringIdentifier
                }).ToListAsync();

                dict[typeUsingISearchableEntity.ToString()] = dtoResult;
            }

            return new SearchAllVM{
                Results = dict
            };
        }

        public static IEnumerable<Type> GetTypesWithISearchableEntity()
        {
            var currentAssembly = typeof(ISearchableEntity).Assembly;
            foreach (Type type in currentAssembly.GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(ISearchableEntity)))
                {
                    yield return type;
                }
            }
        }
    }
}