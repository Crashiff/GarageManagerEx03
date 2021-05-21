using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogicManager
    {
        private GarageLogicManager()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
        }

        private readonly Dictionary<string, Vehicle> m_GarageVehicles;
        private static GarageLogicManager m_Garage;

        public static GarageLogicManager Garage
        {
            get
            {
                if(m_Garage == null)
                {
                    m_Garage = new GarageLogicManager();
                }

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
            foreach (int option in i_WantedStatusVehicles)
            {
                if ((option < (int)Vehicle.eGarageStatus.InRepair || option > (int)Vehicle.eGarageStatus.RepairedAndPaid) && option != 0)
                {
                    throw new ValueOutOfRangeException(
                        (int)Vehicle.eGarageStatus.RepairedAndPaid,
                        (int)Vehicle.eGarageStatus.InRepair);
                }
            }
        }

        public StringBuilder GetListOfVehicleByStatus(int[] i_WantedStatusVehicles)
        {
            StringBuilder licensePlateOfWantedVehicles = new StringBuilder();
            checkIfValuesAreInRange(i_WantedStatusVehicles);
            foreach (Vehicle vehicle in Garage.GarageDictionary.Values)
            {
                if (Array.Exists(i_WantedStatusVehicles, i_X => i_X.Equals((int)vehicle.VehicleGarageStatus)))
                {
                    licensePlateOfWantedVehicles.AppendFormat("{0} is {1}{2}",
                        vehicle.VehicleSerial, vehicle.VehicleGarageStatus.ToString(), Environment.NewLine);
                }
            }

            return licensePlateOfWantedVehicles;
        }

        public void FillPetrol(string carSerial, string petrolType, float petrolAmount)
        {
            Vehicle vehicleToFill = null;
            if (GarageDictionary.TryGetValue(carSerial, out vehicleToFill))
            {
                try
                {
                    PetrolEngine petrolEngineToFill = (PetrolEngine) vehicleToFill.Engine;
                    if (petrolType != petrolEngineToFill.PetrolType)
                    {
                        throw new Exception("ERROR: Wrong petrol type, this vehicle runs on " +
                                            petrolEngineToFill.PetrolType + ", and the input was " + petrolType);
                    }

                    vehicleToFill.Engine.FillVehicle(float.Parse(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    throw new FormatException("ERROR: tried to fill petrol to an electric vehicle");
                }
                catch (Exception otherException)
                {
                    throw otherException;
                }
                
                
            }
            else
            {
                throw new Exception("ERROR: Invalid vehicle serial, this vehicle doesn't exist in the garage");
            }
            
        }

        public void InflateWheels(string carSerial)
        {
            Vehicle vehicleToInflate = null;
            if (GarageDictionary.TryGetValue(carSerial, out vehicleToInflate))
            {
                Wheel[] vehicleWheelsToInflate = vehicleToInflate.Wheels;
                for (int wheelIndex = 0; wheelIndex < vehicleWheelsToInflate.Length; wheelIndex++)
                {
                    vehicleWheelsToInflate[wheelIndex].InflateWheel();
                }
            }
            else
            {
                throw new Exception("ERROR: Vehicle doesn't exist in the garage");
            }
        }

        public void ChargeElectricity(string carSerial, string minutesAmount)
        {
            Vehicle vehicleToCharge = null;
            if (GarageDictionary.TryGetValue(carSerial, out vehicleToCharge))
            {
                try
                {
                    ElectricEngine electricEngineToFill = (ElectricEngine) vehicleToCharge.Engine;
                    electricEngineToFill.FillVehicle(float.Parse(minutesAmount));
                }
                catch (FormatException)
                {
                    throw new FormatException("ERROR: tried to charge with electricity a petrol engine");
                }
                
            }
            else
            {
                throw new Exception("ERROR: Invalid vehicle serial, this car doesn't exist in the garage");
            }

        }

        public void ChangeStatus(string i_CarSerial, string i_UserInput)
        {
            try
            {
                Vehicle.eGarageStatus newStatus = (Vehicle.eGarageStatus) Enum.Parse(typeof(Vehicle.eGarageStatus), i_UserInput);
                Vehicle vehicleToChangeStatus = null;
                if (GarageDictionary.TryGetValue(i_CarSerial, out vehicleToChangeStatus))
                {
                    vehicleToChangeStatus.VehicleGarageStatus = newStatus;
                }
                else
                {
                    throw new Exception("ERROR: The input serial doesn't match any of the cars in the garage");
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("ERROR: Invalid status input, the valid statuses are: (InRepair, Repaired, RepairedAndPaid)");
            }

        }
    }
}
