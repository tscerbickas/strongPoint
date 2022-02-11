namespace Project.WebApi.Models
{
    public class CalculationHistoryItemViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double KineticEnergy { get; set; }
        public double Velocity { get; set; }
        public double Mass { get; set; }
    }
}
