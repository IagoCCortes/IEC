using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileMovies.Commands.UpdateUserProfileMovie
{
    public class UpdateUserProfileMovieCommandHandler : IRequestHandler<UpdateUserProfileMovieCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserProfileMovieCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Unit> Handle(UpdateUserProfileMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfileMovies.FirstOrDefaultAsync(u => u.MovieId == request.MovieId && u.UserProfileId == request.UserProfileId);

            if (entity == null)
                throw new NotFoundException(nameof(UserProfileMovie), new { request.UserProfileId, request.MovieId });

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}