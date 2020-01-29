using MediatR;

namespace Application.SearchAll
{
    public class GetSearchAllQuery : IRequest<SearchAllVM>
    {
        public string SearchIn { get; set; }
        public string ValueToSearch { get; set; }
    }
}