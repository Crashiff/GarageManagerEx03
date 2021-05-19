using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;

        public  float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }
        private float m_MinValue;

        public  float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }


        public ValueOutOfRangeException(string i_Message, float i_MaxValue, float i_MinValue) : base(i_Message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) : base("Value was out of range valid range is: " + i_MinValue + " - " + i_MaxValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

    }
}