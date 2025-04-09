using Marten;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Techs.Api.Techs;

[ApiController]
public class TechsController(IDocumentSession documentSession) : ControllerBase
{
    [HttpPost("/techs")]
    public async Task<ActionResult> AddAVendorAsync([FromBody] TechCreateModel request,
        [FromServices] IValidator<TechCreateModel> validator
        )
    {




        var validationResults = validator.Validate(request);
        if (!validationResults.IsValid)
        {
            return BadRequest(validationResults.ToDictionary());
        }

        // create the thing we are going to save in the database (mapping)
        //var entityToSave = new TechEntity
        //{
        //    Id = Guid.NewGuid(),
        //    FirstName = request.FirstName,
        //    LastName = request.LastName,
        //    Sub = request.Sub,
        //    Email = request.Email,
        //    Phone = request.Phone,
        //};
        //documentSession.Store(entityToSave);
        await documentSession.SaveChangesAsync();
        // save it
        // map it to the thing we are going to return.

        //return Created($"/techs/{entityToSave.Id}", entityToSave);
    }
}