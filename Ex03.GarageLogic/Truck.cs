using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Truck : Vehicle
    {
        private float m_MaximumWeightCapacity;
        private bool m_ContainsDangerousMaterials;

        private const int k_TruckMaxWheelPressure = 26;
        private const int k_NumberOfWheels = 16;

        private const string k_PetrolType = "Soler";
        private const float k_MaxPetrolLiterCapacity = 120.0f;

        public float MaximumWeightCapacity
        {
            get { return MaximumWeightCapacity; }
            set { m_MaximumWeightCapacity = value; }
        }

        public bool IfContainsDangerousMaterialsYesOrNo
        {
            get { return m_ContainsDangerousMaterials; }
            set { m_ContainsDangerousMaterials = value; }
        }

        public Truck(bool isElectric)
        {
            m_VehicleWheels = VehicleCreator.createWheels(k_NumberOfWheels, k_TruckMaxWheelPressure);
            m_VehicleEngine = VehicleCreator.CreateEngine(isElectric);

            PetrolEngine petrolEngine = m_VehicleEngine as PetrolEngine;
            petrolEngine.MaximumPetrolAmount = k_MaxPetrolLiterCapacity;
            petrolEngine.PetrolType = k_PetrolType;

        }

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case (int)eTruckProperties.MaximumWeightCapacity:
                {
                    float MaximumCapacityInput= float.Parse(i_UserInput);
                    if (!(MaximumCapacityInput > 0))
                    {
                        throw new Exception("ERROR: Invalid capacity input, input must be a positive number");
                    }
                    else
                    {
                        m_MaximumWeightCapacity = MaximumCapacityInput;
                    }
                    break;
                }
                case (int)eTruckProperties.ContainsDangerousMaterialsYesOrNo:
                {
                    if (i_UserInput == "Yes" || i_UserInput == "yes")
                    {
                        m_ContainsDangerousMaterials = true;
                    }
                    else if (i_UserInput == "No" || i_UserInput == "no")
                    {
                        m_ContainsDangerousMaterials = false;
                    }
                    else
                    {
                        throw new Exception("ERROR: Invalid answer, please answer weather the truck contains dangerous materials, Yes or No");
                    }
                    break;
                }
            }
        }

        public override string[] GetPropertiesNames()
        {
            return Enum.GetNames(typeof(eTruckProperties));
        }

        private enum eTruckProperties
        {
            MaximumWeightCapacity = 0,
            ContainsDangerousMaterialsYesOrNo
        }
    }
}