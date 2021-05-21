
using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public override void FillVehicle(float i_petrolAmountToAdd)
        {
            if (i_petrolAmountToAdd < 0)
            {
                throw new Exception("ERROR: input amount was a negative value");
            }

            if (m_RemainingBatteryHours + i_petrolAmountToAdd > m_MaximumBatteryHours)
            {
                throw new Exception("ERROR: Overflow, input amount was too high, The maximum amount is " +
                                    m_MaximumBatteryHours + " ,the current amount is " + m_RemainingBatteryHours +
                                    " and the input was " + i_petrolAmountToAdd);
            }

            m_RemainingBatteryHours += i_petrolAmountToAdd;
            EnergyPercentage = m_RemainingBatteryHours / m_MaximumBatteryHours;
        }

        private float m_RemainingBatteryHours;
        private float m_MaximumBatteryHours;

        public float RemainingBatteryHours
        {
            get { return m_RemainingBatteryHours; }
            set { m_RemainingBatteryHours = value; }
        }

        public float MaximumBatteryHours
        {
            get { return m_MaximumBatteryHours; }
            set { m_MaximumBatteryHours = value; }
        }
    }
}
