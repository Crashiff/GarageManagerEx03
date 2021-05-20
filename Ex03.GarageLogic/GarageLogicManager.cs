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
 private static void checkIfValuesAreInRange(int[] i_WantedStatusVehicles)
        {
            foreach(int option in i_WantedStatusVehicles)
            {
                if(option < (int)Vehicle.eGarageStatus.InRepair || option > (int)Vehicle.eGarageStatus.RepairedAndPaid)
                {
                    throw new ValueOutOfRangeException(
                        (int)Vehicle.eGarageStatus.RepairedAndPaid,
                        (int)Vehicle.eGarageStatus.InRepair);
                }
            }
        }
        public static StringBuilder GetListOfVehicleByStatus(int[] i_WantedStatusVehicles)
        {
            StringBuilder licensePlateOfWantedVehicles = new StringBuilder();
            checkIfValuesAreInRange(i_WantedStatusVehicles);
            foreach (Vehicle vehicle in Garage.GarageDictionary.Values)
            {
                if (Array.Exists(i_WantedStatusVehicles, i_X => i_X.Equals(vehicle.GarageStatus)))
                {
                    licensePlateOfWantedVehicles.AppendFormat("{0} is {1}{2}", 
                        vehicle.VehicleSerial, vehicle.GarageStatus.ToString(), Environment.NewLine);
                }
            }

            return licensePlateOfWantedVehicles;
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
