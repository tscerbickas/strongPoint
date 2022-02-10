namespace Project.WebApi.Models
{
    public class KineticEnergyCalculatorModel
    {
        public double Mass { get; set; }
        public double Velocity { get; set; }

        internal void Deconstruct(out double mass, out double velocity)
        {
            mass = Mass;
            velocity = Velocity;
        }
    }
}
