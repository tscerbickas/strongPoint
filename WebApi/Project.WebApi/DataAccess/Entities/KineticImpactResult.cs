namespace Project.WebApi.DataAccess.Entities
{
    public class KineticImpactResult : Entity
    {
        protected KineticImpactResult()
        {

        }

        public KineticImpactResult(int energy, string description)
        {
            NewEntry();

            KineticEnergity = energy;
            Description = description;
        }

        public int KineticEnergity { get; private set; }
        public string Description { get; private set; }

        internal void Deconstruct(out Guid id, out string description)
        {
            id = Id;
            description = Description;
        }
    }
}
