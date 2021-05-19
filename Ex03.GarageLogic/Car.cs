using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor      m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        public const int       k_CarMaxWheelPressure = 32;

        public eCarColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case 1:
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
                case 2:
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

        public Car()
        {

        }

        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black
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
