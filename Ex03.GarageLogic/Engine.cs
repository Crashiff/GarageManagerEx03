
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public abstract void FillVehicle(float i_petrolAmountToAdd);

        private float m_EnergyPercentage;

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }
    }
}
