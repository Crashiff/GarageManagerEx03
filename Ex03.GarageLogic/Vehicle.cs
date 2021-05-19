
using System;
using System.Reflection;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        protected string m_VehicleBrand; //v// input
        protected string m_VehicleSerial;
        protected float m_EnergyPercentage;
        protected Wheel[] m_VehicleWheels;
        Engine m_VehicleEngine = null;
        
        protected string m_OwnerName;
        protected int m_OwnerPhoneNumber;
        protected int m_GarageStatus;
        public int GarageStatus
        {
            get;
        }

        public abstract void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex);

        //protected Vehicle()
        //{
        //     string m_VehicleBrand = null;
        //     string m_VehicleSerial = null;
        //     float m_EnergyPercentage = 0.0f;
        //     Wheel[] m_VehicleWheels = null;
        //     Engine m_VehicleEngine = null;
        //}

        public static ParameterInfo[] GetParametersInformation()
        {

            ParameterInfo[] allParams = typeof(Vehicle).GetConstructor(new Type[2] {typeof(string), typeof(string)}).GetParameters();
            return allParams;
        }

        public enum eGarageStatus
        {
            InRepair = 1,
            Repaired,
            RepairedAndPaid
        }
    }
}