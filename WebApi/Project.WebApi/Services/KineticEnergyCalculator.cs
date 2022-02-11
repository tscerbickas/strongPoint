namespace Project.WebApi.Services;

public interface IKineticEnergyCalculator
{
    double Calculate(double mass, double velocity);
}

public class KineticEnergyCalculator : IKineticEnergyCalculator
{
    private readonly ILogger<KineticEnergyCalculator> _logger;

    public KineticEnergyCalculator(ILogger<KineticEnergyCalculator> logger)
    {
        _logger = logger;
    }

    public double Calculate(double mass, double velocity)
    {
        if (mass <= 0)
        {
            throw new ArgumentException($"{nameof(mass)} should be greater than 0");
        }

        if (velocity <= 0)
        {
            throw new ArgumentException($"{nameof(velocity)} should be greater than 0");
        }

        var kineticEnergy = (mass * Math.Pow(velocity, 2)) * 0.5;

        _logger.LogInformation("Calculated kinetic energy, mass:{mass}, velocity:{velocity}, kineticEnergy:{ke}", mass, velocity, kineticEnergy);

        return kineticEnergy;
    }
}
