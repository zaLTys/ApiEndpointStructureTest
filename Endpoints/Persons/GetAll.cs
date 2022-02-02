using ApiEndpointStructureTest.Models;
using ApiEndpointStructureTest.Services;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpointStructureTest.Endpoints.Persons
{
    public class GetAll : EndpointBaseAsync
        .WithoutRequest
        .WithResult<List<Person>>
    {
        private readonly IPersonsService _personsService;

        public GetAll(IPersonsService personsService) { _personsService = personsService; }

        [HttpGet("persons")]
        public override async Task<List<Person>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _personsService.GetAllAsync();
        }
    }
}
