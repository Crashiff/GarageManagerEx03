using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor      m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        private const int       k_CarMaxWheelPressure = 32;
        private const int k_NumberOfWheels = 4;

        private const string k_PetrolType = "Octan95";
        private const float k_MaxPetrolLiterCapacity = 45.0f;
        private const float k_MaxBatteryHoursCapacity = 3.2f;

        public Car(bool isElectric)
        {
            m_VehicleWheels = VehicleCreator.createWheels(k_NumberOfWheels, k_CarMaxWheelPressure);

            m_VehicleEngine = VehicleCreator.CreateEngine(isElectric);
            if (isElectric)
            {
                ElectricEngine electricEngine = m_VehicleEngine as ElectricEngine;
                electricEngine.MaximumBatteryHours = k_MaxBatteryHoursCapacity;
            }
            else
            {
                PetrolEngine petrolEngine = m_VehicleEngine as PetrolEngine;
                petrolEngine.MaximumPetrolAmount = k_MaxPetrolLiterCapacity;
                petrolEngine.PetrolType = k_PetrolType;
            }
        
        }

        public eCarColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case (int)eCarProperties.CarColor:
                {
                    eCarColor inputColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_UserInput);
                    if (!(Enum.IsDefined(typeof(eCarColor), i_UserInput)))
                    {
                        throw new Exception("This color doesn't exist, valid colors are: { Red, Silver, White, Black }");
                    }
                    else
                    {
                        m_CarColor = inputColor;
                    }
                    break;
                }
                case (int)eCarProperties.NumberOfDoors:
                {
                    eNumberOfDoors inputNumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_UserInput);
                    if (!(Enum.IsDefined(typeof(eNumberOfDoors), int.Parse(i_UserInput)) || Enum.IsDefined(typeof(eNumberOfDoors), i_UserInput)))
                    {
                        throw new Exception("Invalid number of doors input, please enter a number between 2 and 5");
                    }
                    else
                    {
                        m_NumberOfDoors = inputNumberOfDoors;
                    }
                    break;
                }
            }
        }



        //public override string ToString()
        //{
        //    StringBiulder carToPrint = new StringBiulder();
        //    carToPrint.AppendFormat(@"{0} Car:
        //                              {1}{2}{3}{4}{5}{6}" , base.ToString() , )
        //    return 
        //}


        public override string[] GetPropertiesNames()
        {
            return Enum.GetNames(typeof(eCarProperties));
        }

        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }

        private enum eCarProperties
        {
            CarColor = 0,
            NumberOfDoors
        }

        public enum eNumberOfDoors
        {
            Coupe = 2,
            CoupeHatchBack = 3,
            Sedan = 4,
            SedanHatchBack = 5
        }
    }
}
