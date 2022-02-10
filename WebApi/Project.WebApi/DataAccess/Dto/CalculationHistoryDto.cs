namespace Project.WebApi.DataAccess.Dto
{
    public class CalculationHistoryDto
    {
        public Guid Id { get;set; }

        public string Description { get; set; }

        public double KineticEnergy { get;  set; }
        public double Velocity { get;  set; }
        public double Mass { get;  set; }
    }
}
