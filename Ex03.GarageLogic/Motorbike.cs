using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int          m_EngineVolume;

        private const int k_MotorbikeMaxWheelPressure = 30;
        private const int k_NumberOfWheels = 2;

        private const string k_PetrolType = "Octan98";
        private const float k_MaxPetrolLiterCapacity = 6.0f;
        private const float k_MaxBatteryHoursCapacity = 1.8f;

        public enum eLicenseType
        {
            A = 1,
            B1,
            AA,
            BB
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public Motorbike(bool isElectric)
        {
            m_VehicleWheels = VehicleCreator.createWheels(k_NumberOfWheels, k_MotorbikeMaxWheelPressure);
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

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case (int)ePropertyList.LicenseType:
                    eLicenseType inputLicense = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_UserInput);
                    if (!(Enum.IsDefined(typeof(eLicenseType), i_UserInput)))
                    {
                        throw new Exception("ERROR: Invalid license type, valid licenses are: { A, B1, AA, BB }");
                    }
                    else
                    {
                        m_LicenseType = inputLicense;
                    }
                    break;
                case (int)ePropertyList.EngineVolume:
                    int engineVolumeInput = int.Parse(i_UserInput);
                    if (!(engineVolumeInput > 0))
                    {
                        throw new Exception("Invalid engine volume, input must be a positive integer");
                    }
                    else
                    {
                        m_EngineVolume = engineVolumeInput;
                    }
                    break;
            }
        }

        public override string[] GetPropertiesNames()
        {
            return Enum.GetNames(typeof(ePropertyList));
        }

        private enum ePropertyList
        {
            LicenseType = 0,
            EngineVolume
        }
    }
}
