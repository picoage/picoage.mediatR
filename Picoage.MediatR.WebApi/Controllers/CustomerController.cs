using MediatR;
using Microsoft.AspNetCore.Mvc;
using Picoage.MediatR.Application.Commands;
using Picoage.MediatR.Application.Models.RequestModels;
using Picoage.MediatR.Application.Queries;
using Picoage.MediatR.WebApi.Controllers;
using System.Threading.Tasks;

public class CustomerController : BaseController
{
    private readonly IMediator mediator;

    public CustomerController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> GetCustomer(int Id)
    {
        return Ok(await mediator.Send(new CustomerQuery(Id)));
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody]CustomerRequest customer)
    {
        var results = await mediator.Send(new CustomerCommand(customer));
        return CreatedAtAction("GetCustomer", new { Id = results.Id }, results);

    }
}