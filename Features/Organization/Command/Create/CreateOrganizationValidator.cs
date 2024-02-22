using System.Net;
using FluentValidation;

public class CreateOrganizationValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationValidator()
    {
        RuleFor(command => command.Name)
        .NotEmpty()
        .WithMessage("Name is required");

        //fluent interface pattern

        RuleFor(command => command.Image!.FileName)
        .NotEmpty()
        .Must(filename =>
        filename.EndsWith(".jpeg") ||
        filename.EndsWith(".png") ||
        filename.EndsWith(".svg")
        )
        .WithMessage("Unsupported file type. ");


        RuleFor(command => command.Image!.Length)
        .NotNull()
        .LessThanOrEqualTo(2 * 1024 * 1024)
        .WithMessage("2MB size limit exceeded");



    }



}