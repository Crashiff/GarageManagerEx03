using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class PetrolEngine : Engine
    {
        public override void FillVehicle(float i_petrolAmountToAdd)
        {

        }

        protected string m_PetrolType;
        protected float  m_CurrentPetrolAmount;
        protected float  m_MaximumPetrolAmount;

        enum ePetrolType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

    }
}
