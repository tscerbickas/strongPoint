namespace Project.WebApi.DataAccess.Entities
{
    public class CalculationHistory : Entity
    {
        protected CalculationHistory()
        {

        }

        public CalculationHistory(
            double velocity, 
            double mass, 
            double kineticEnergy, 
            Guid impactResultId,
            Guid uniqueIdentifier)
        {
            Velicoty = velocity;
            Mass = mass;
            KineticEnergy = kineticEnergy;

            ImpactResultId = impactResultId;
            UniqueIdentifier = uniqueIdentifier;

            NewEntry();
        }

        public double KineticEnergy { get; private set; }
        public double Velicoty { get; private set; }
        public double Mass { get; private set; }

        public Guid UniqueIdentifier { get; private set; }

        public Guid ImpactResultId { get; private set; }
        public KineticImpactResult ImpactResult { get; private set; }
    }
}
