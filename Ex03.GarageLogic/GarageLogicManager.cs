using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class GarageLogicManager
    {
        private GarageLogicManager()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
            m_Garage = new GarageLogicManager();
        }

        private Dictionary<string, Vehicle> m_GarageVehicles;
        private static GarageLogicManager m_Garage;

        public static GarageLogicManager Garage
        {
            get
            {
                return m_Garage;
            }
        }

        public Dictionary<string, Vehicle> GarageDictionary
        {
            get
            {
                return m_GarageVehicles;
            }
        }

        public string[] GetListOfVehicleByStatus(int[] i_WantedStatusVehicles)
        {

            foreach(Vehicle vehicle in Garage)
            {
                if (i_WantedStatusVehicles.find(vehicle.GarageStatus)
                {

                }


            }

        }

        //public enum eVehicleType
        //{
        //    ElectricCar   = 1,
        //    PetrolCar    = 2,
        //    ElectricBike = 3,
        //    PetrolBike   = 4,
        //    Truck        = 5
        //}

        public void FillPetrol(string carSerial, string petrolType, float petrolAmount)
        {
            Vehicle vehicleToFill = null;
            GarageDictionary.TryGetValue(carSerial, out vehicleToFill);
            
        }

        public void InflateWheels(string carSerial)
        {
            Vehicle vehicleToInflate = null;
            GarageDictionary.TryGetValue(carSerial, out vehicleToInflate);
        }

        public void ChargeElectricity(string carSerial, float minutesAmount)
        {
            Vehicle vehicleToCharge = null;
            GarageDictionary.TryGetValue(carSerial, out vehicleToCharge);
            if (vehicleToCharge == null)
            {
                //throw exception
            }
            else
            {
               //(VehicleToCharge.Engine as ElectricEngine).Charge(minutesAmount;
            }

        }
    }
}
