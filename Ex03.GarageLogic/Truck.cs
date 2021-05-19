using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Truck : Vehicle
    {
        private float m_MaximumWeightCapacity;
        private bool m_ContainsDangerousMaterials;

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

        public Truck()
        {
            
        }

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case 1:
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
                case 2:
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

        public int k_MaxWheelPressure = 26;
    }
}