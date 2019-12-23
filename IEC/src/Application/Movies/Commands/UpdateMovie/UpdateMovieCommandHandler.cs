using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMovieCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                        .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (movie == null)
                throw new NotFoundException(nameof(Movie), request.Id);

            _mapper.Map(request, movie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}