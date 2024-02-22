using MediatR;

public class CreateOrganizationCommand : IRequest<CreateOrganizationResponse>
{
    public string? Name { get; set; }
    public IFormFile? Image { get; set; }


}


