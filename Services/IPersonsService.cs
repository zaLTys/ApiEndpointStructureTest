using ApiEndpointStructureTest.Models;

namespace ApiEndpointStructureTest.Services
{
    public interface IPersonsService
    {
        Task<bool> CreateAsync(Person? person);
        Task<Person> UpdateAsync(Guid Id, Person person);
        Task<List<Person>> GetAllAsync();
    }
}
