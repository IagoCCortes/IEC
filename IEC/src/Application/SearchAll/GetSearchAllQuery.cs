using MediatR;

namespace Application.SearchAll
{
    public class GetSearchAllQuery : IRequest<SearchAllVM>
    {
        public string ValueToSearch { get; set; }
    }
}