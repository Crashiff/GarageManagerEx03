using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        private const bool v_Electric = true;
        private const bool v_Petrol = false;

        public static Vehicle CreateVehicle(VehicleCreator.eVehicleTypes chosenVehicleOption)
        {
            Vehicle createdVehicle = null;

            switch (chosenVehicleOption)
            {
                case eVehicleTypes.ElectricCar:
                {
                    
                    createdVehicle = new Car(v_Electric);
                    break;
                    
                }
                case eVehicleTypes.PetrolCarWithOctan95:
                {
                    createdVehicle = new Car(v_Petrol);
                    break;
                }
                case eVehicleTypes.PetrolMotorbikeWithOctan98:
                {
                    createdVehicle = new Motorbike(v_Petrol);
                    break;
                    }
                case eVehicleTypes.ElectricMotorbike:
                {
                    createdVehicle = new Motorbike(v_Electric);
                    break;
                    }
                case eVehicleTypes.TruckWithSoler:
                {
                    createdVehicle = new Truck(v_Petrol);
                    break;
                }
            }

            return createdVehicle;
        }

        public static Engine CreateEngine(bool i_IsElectric)
        {
            Engine createdEngine = null;
            return i_IsElectric ? createdEngine = new ElectricEngine() : createdEngine = new PetrolEngine();
        }

        public static Wheel[] createWheels(int i_AmountOfWheels, int i_MaxWheelPressure)
        {
             Wheel[] Wheels = new Wheel[i_AmountOfWheels];
             for (int wheelIndex = 0; wheelIndex < Wheels.Length; wheelIndex++)
             {
                 Wheels[wheelIndex] = new Wheel(i_MaxWheelPressure);
             }

             return Wheels;
        }

        public enum eVehicleTypes
        {
            ElectricCar = 1,
            PetrolCarWithOctan95, 
            ElectricMotorbike,
            PetrolMotorbikeWithOctan98,
            TruckWithSoler
        }
    }
}
