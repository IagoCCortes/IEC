using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieReturnDto>
    {
        private readonly IIECDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IIECDbContext context, IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<CreateMovieReturnDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request);

            _context.Movies.Add(movie);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new MovieCreated { Id = movie.Id }, cancellationToken);

            return _mapper.Map<CreateMovieReturnDto>(movie);
        }
    }
}