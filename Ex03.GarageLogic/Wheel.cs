using System;
using System.Text;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_BrandName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        public string BrandName
        {
            get { return m_BrandName; }
            set { m_BrandName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public Wheel(int i_MaxWheelPressure)
        {
            m_MaxAirPressure = i_MaxWheelPressure;
        }

        //public override string ToString()
        //{
        //    StringBuilder wheelToPrint = new StringBuilder();
        //    wheelToPrint.AppendFormat("wheels:{2}air pressure: {0}{2} Brand: {1} " ,CurrentAirPressure , BrandName , Environment.NewLine);
        //    return;
        //}

        public void InflateWheel()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }
    }
}