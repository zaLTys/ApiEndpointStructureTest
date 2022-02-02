using ApiEndpointStructureTest.Models;

namespace ApiEndpointStructureTest.Services
{
    public class PersonService : IPersonsService
    {
        private readonly Dictionary<Guid, Person> _persons = new();
        public Task<bool> CreateAsync(Person? person)
        {
            if (person == null)
            {
                return Task.FromResult(false);
            }
            _persons[person.Id] = person;
            return Task.FromResult(true);
        }

        public Task<Person> UpdateAsync(Guid Id, Person person)
        {
            _persons[Id].FirstName = person.FirstName;
            _persons[Id].LastName = person.LastName;
            return Task.FromResult(_persons[Id]);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var persons = _persons.Select(x => x.Value).ToList();
            return await Task.FromResult(persons);
        }
    }
}
