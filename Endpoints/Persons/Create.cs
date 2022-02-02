using ApiEndpointStructureTest.Models;
using ApiEndpointStructureTest.Services;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpointStructureTest.Endpoints.Persons
{
    public class Create : EndpointBaseAsync
        .WithRequest<Person> //should be model ofc
        .WithResult<bool>
    {
        private readonly IPersonsService _personsService;

        public Create(IPersonsService personsService) { _personsService = personsService; }

        [HttpPost("persons/create")]
        public override async Task<bool> HandleAsync(Person request, CancellationToken cancellationToken = default)
        {
            var person = new Person() { FirstName = "Povilas", Id = Guid.NewGuid(), LastName = "Simanskas" };
            var result = await _personsService.CreateAsync(person);
            return result;
        }
    }
}
