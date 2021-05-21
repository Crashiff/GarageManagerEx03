using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class PetrolEngine : Engine
    {
        public override void FillVehicle(float i_petrolAmountToAdd)
        {
            if (i_petrolAmountToAdd < 0)
            {
                throw new Exception("ERROR: input amount was a negative value");
            }

            if (m_CurrentPetrolAmount + i_petrolAmountToAdd > m_MaximumPetrolAmount)
            {
                throw new Exception("ERROR: Overflow, input amount was too high, The maximum amount is " +
                                    m_MaximumPetrolAmount + " ,the current amount is " + m_CurrentPetrolAmount +
                                    " and the input was " + i_petrolAmountToAdd);
            }

            m_CurrentPetrolAmount += i_petrolAmountToAdd;
            EnergyPercentage = m_CurrentPetrolAmount / m_MaximumPetrolAmount;
        }

        protected string m_PetrolType;
        protected float  m_CurrentPetrolAmount;
        protected float  m_MaximumPetrolAmount;

        public string PetrolType
        {
            get { return m_PetrolType; }
            set { m_PetrolType = value; }
        }

        public float CurrentPetrolAmount
        {
            get { return m_CurrentPetrolAmount; }
            set { m_CurrentPetrolAmount = value; }
        }

        public float MaximumPetrolAmount
        {
            get { return m_MaximumPetrolAmount; }
            set { m_MaximumPetrolAmount = value; }
        }

        enum ePetrolType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

    }
}
