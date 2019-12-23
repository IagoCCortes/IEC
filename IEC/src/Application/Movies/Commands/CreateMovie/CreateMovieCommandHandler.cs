using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
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

        public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var Movie = _mapper.Map<Movie>(request);

            _context.Movies.Add(Movie);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new MovieCreated { Id = Movie.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}