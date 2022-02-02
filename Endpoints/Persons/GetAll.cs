using ApiEndpointStructureTest.Models;
using ApiEndpointStructureTest.Services;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiEndpointStructureTest.Endpoints.Persons
{
    public class GetAll : EndpointBaseAsync
        .WithoutRequest
        .WithResult<List<Person>>
    {
        private readonly IPersonsService _personsService;

        public GetAll(IPersonsService personsService) { _personsService = personsService; }

        [HttpGet("persons")]
        [SwaggerOperation(Summary = "Get all persons",
            Description = "Get all persons",
            OperationId = "Person.GetAll",
            Tags = new []{"PersonEndpoint"})]
        public override async Task<List<Person>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _personsService.GetAllAsync();
        }
    }
}
