using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        public const int     k_BikeMaxWheelPressure = 30;
        private eLicenseType m_LicenseType;
        private int          m_EngineVolume;

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

        public Motorbike()
        {

        }

        public override void UpdatePropertyByStringInputAndPropertyIndex(string i_UserInput, int PropertyIndex)
        {
            switch (PropertyIndex)
            {
                case 1:
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
                case 2://change to enum ?
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
    }
}
