using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/organization")]
public class OrganizationController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateOrganizationResponse>> Add([FromQuery] CreateOrganizationCommand command)
    {

        var resposne = await _mediator.Send(command);
        return Ok(resposne);


        // async await chai basically kei operation jun chai time lagcha tyo operation lai async banayera run garna ko lagi use garincha

        //race condition 

        //define wahta async await does 

    }

    /// http request send wa recieve garna ko lagi
    /// data base sanga communicate garna ko lagi
    /// 

    // backend to backend communication garna ko lagi
    // hamro backend bata arko backend ma request pathauna ko lagi

}