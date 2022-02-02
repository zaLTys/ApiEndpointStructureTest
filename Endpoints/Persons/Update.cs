using ApiEndpointStructureTest.Attributes;
using ApiEndpointStructureTest.Models;
using ApiEndpointStructureTest.Services;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiEndpointStructureTest.Endpoints.Persons
{
    public class UpdateRequest
    {
        [FromRoute(Name = "id")] public Guid Id { get; init; }
        [FromBody] public Person UpdatedPerson { get; set; } = default!;
    }

    public class Update : EndpointBaseAsync
        .WithRequest<UpdateRequest> //should be model ofc
        .WithResult<Person>
    {
        private readonly IPersonsService _personsService;

        public Update(IPersonsService personsService) { _personsService = personsService; }

        [HttpPut("persons/{id:guid}")]
        [SwaggerOperation(Summary = "Update person",
            Description = "Update person",
            OperationId = "Person.Update",
            Tags = new[] { "PersonEndpoint" })]
        public override async Task<Person> HandleAsync(
            [FromMultiSource]UpdateRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _personsService.UpdateAsync(request.Id, request.UpdatedPerson);
            return result;
        }
    }
}
