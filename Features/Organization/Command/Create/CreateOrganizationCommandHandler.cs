using FluentValidation;
using MediatR;

public class CreateOrganizationCommandHandler(IOrganizationRepository _organizationRepository) : IRequestHandler<CreateOrganizationCommand, CreateOrganizationResponse>
{
    public async Task<CreateOrganizationResponse> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateOrganizationResponse();
        var validator = new CreateOrganizationValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            response.Message = "Validation error in request";
            foreach (var error in validationResult.Errors)
            {
                throw new ValidationException(error.ErrorMessage);
            }
            return response;
        }

        Organization organization = new()
        {
            Name = request.Name,
            Image = FileToByteArray(request.Image!)
        };
        await _organizationRepository.CreateOrganization(organization);
        response.Message = "Oragnization Created Succesfully";
        return response;



    }


    private byte[] FileToByteArray(IFormFile file)
    {
        if (file.Length == 0 || file == null)
        {
            return null;
        }

        MemoryStream memoryStream = new();
        file.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream.ToArray();
    }

}