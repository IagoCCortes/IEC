using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommandHandler : IRequestHandler<UpdateUserMovieCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserMovieCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Unit> Handle(UpdateUserMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserMovies.FirstOrDefaultAsync(u => u.MovieId == request.MovieId && u.UserId == request.UserId);

            if (entity == null)
                throw new NotFoundException(nameof(UserMovie), new { request.UserId, request.MovieId });

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}