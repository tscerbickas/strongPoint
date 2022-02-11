namespace Project.WebApi.Models;

public class KineticEnergyCalculatorViewModel
{
    public KineticEnergyCalculatorViewModel(double energy, string description)
    {
        KineticEnergy = energy;
        Description = description;
    }

    public double KineticEnergy { get; set; }
    public string Description { get; set; }
}

