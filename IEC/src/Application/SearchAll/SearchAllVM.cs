using System.Collections.Generic;

namespace Application.SearchAll
{
    public class SearchAllVM
    {
        public Dictionary<string, List<SearchAllLookupDto>> Results { get; set; }

        public SearchAllVM()
        {
            Results = new Dictionary<string, List<SearchAllLookupDto>>();
        }
    }
}