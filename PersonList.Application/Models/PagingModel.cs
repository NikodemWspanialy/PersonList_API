using PersonList.Application.Person.Dtos;

namespace PersonList.Application.Models
{
    public class PagingModel
    {
        public int Page { get; set; } = 0;
        public int Count { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public IEnumerable<PersonDto> Persons { get; set; } = new List<PersonDto>();
    }
}
