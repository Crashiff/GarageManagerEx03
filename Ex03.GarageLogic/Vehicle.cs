using System.Text;
using System;
using System.Reflection;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        protected string m_VehicleBrand;
        protected string m_VehicleSerial; //v// input
        protected float m_EnergyPercentage; //v// input
        protected Wheel[] m_VehicleWheels;
        protected Engine m_VehicleEngine;

        protected string m_OwnerName;
        protected int m_OwnerPhoneNumber;
        protected eGarageStatus m_GarageStatus;

        public string VehicleBrand
        {
            get { return m_VehicleBrand; }
            set { m_VehicleBrand = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public int OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public string VehicleSerial
        {
            get { return m_VehicleSerial; }
            set { m_VehicleSerial = value; }
        }

        public eGarageStatus VehicleGarageStatus
        {
            get { return m_GarageStatus; }
            set { m_GarageStatus = value; }
        }

        public Wheel[] Wheels
        {
            get { return m_VehicleWheels; }
            set { m_VehicleWheels = value; }
        }

        public Engine Engine
        {
            get { return m_VehicleEngine; }
            set { m_VehicleEngine = value; }
        }

        public virtual String ToString()
        {
            StringBuilder VehicleToPront = new StringBuilder();
            VehicleToPront.AppendFormat(
                @"Serial: {0}
                 Brand: {1}
                 Owner: {2}
                 Phone Number: {3}
                 {4}
                 Garage status: {5}",
                VehicleSerial, VehicleBrand, OwnerName,
                OwnerPhoneNumber, Wheels[0].ToString() , VehicleGarageStatus.ToString());

            return VehicleToPront.ToString();
        }

        public abstract string[] GetPropertiesNames();
        public abstract void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex);

        public enum eGarageStatus
        {
            InRepair = 1,
            Repaired,
            RepairedAndPaid
        }
    }
}