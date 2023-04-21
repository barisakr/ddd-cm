using FluentValidation;

namespace ChargeManagement.Application.Menus.Commands.CreateMenu
{
    public class RegisterCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}