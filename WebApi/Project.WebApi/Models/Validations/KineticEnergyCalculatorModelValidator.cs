using FluentValidation;

namespace Project.WebApi.Models.Validations
{
    public class KineticEnergyCalculatorModelValidator : AbstractValidator<KineticEnergyCalculatorModel> 
    {
        public KineticEnergyCalculatorModelValidator()
        {
            RuleFor(c => c.Mass).GreaterThan(0);
            RuleFor(c => c.Velocity).GreaterThan(0);
        }
    }
}
