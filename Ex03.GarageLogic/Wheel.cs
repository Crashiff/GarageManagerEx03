using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_BrandName;

        public string BrandName
        {
            get;
            private set;
        }

        private float m_CurrentAirPressure;

        public float CurrentAirPressure
        {
            get;
            private set;
        }

        private float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get;
            private set;
        }

        public bool InflateWheel(float i_AmountOfAirToInflate)
        {
            const bool k_IsValidAirPressure = true;
            if (!(CurrentAirPressure + i_AmountOfAirToInflate > MaxAirPressure))
            {
                throw new Exception("Air pressure overflow in wheels");
            }

            CurrentAirPressure += i_AmountOfAirToInflate;

            return k_IsValidAirPressure;
        }
    } // Class Wheel 
} // namespace