using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(/*string carSerial*/int i_vehicleIndex)
        {
            //if (GarageLogicManager.Garage.GarageDictionary.ContainsKey(carSerial))
            //{
            //    Vehicle toGet = null;
            //    GarageLogicManager.Garage.GarageDictionary.TryGetValue(carSerial, out toGet);
            //}
            Vehicle createdVehicle = null;

            switch (i_vehicleIndex)
            {
                case 1:
                {
                    createdVehicle = new Car();
                    break;
                }
                case 2:
                {
                    createdVehicle = new Motorbike();
                    break;
                }
                case 3:
                {
                    createdVehicle = new Truck();
                    break;
                }

            }

            return createdVehicle;
        }


        //public enum eVehicleType
        //{
        //    ElectricCar = 1,
        //    PetrolCar = 2,
        //    ElectricBike = 3,
        //    PetrolBike = 4,
        //    Truck = 5
        //}

        public static Engine CreateEngine(bool i_IsElectric)
        {
            Engine createdEngine = null;
            return i_IsElectric ? createdEngine = new ElectricEngine() : createdEngine = new PetrolEngine();
        }

        public static Wheel createWheel(int i_AmountOfWheels)
        {
            return new Wheel(); ///change
        }

        public static ParameterInfo[] GetConstructorParametersInformation()
        {
            return VehicleTypes[0].GetConstructor(new Type[2] { typeof(string), typeof(string) }).GetParameters();
            
        }

        public static void GetPropertiesInformation(int indexOfVehicle )
        {
            Vehicle some = new Car();
            //return VehicleTypes[indexOfVehicle].GetProperties();
            PropertyInfo[] propInfo = VehicleTypes[indexOfVehicle].GetProperties();
            foreach (PropertyInfo property in propInfo)
            {
                if (property.PropertyType != typeof(string))
                {
                    Console.WriteLine("Please enter: " + property.Name);
                    MethodInfo ParseMethod = property.PropertyType.GetMethod("Parse", new Type[1] { typeof(string) });
                    property.SetValue(some ,ParseMethod.Invoke(null, new object[1] {Console.ReadLine()} ), null);
                }
                else
                {
                    Console.WriteLine("Please enter: " + property.Name);
                    property.SetValue(some, Console.ReadLine(), null);
                }
             
                
            }

        }
        public static PropertyInfo[] GetPropertiesInformation(bool isElectric)
        {
            return isElectric ? typeof(ElectricEngine).GetProperties() : typeof(PetrolEngine).GetProperties();

        }

        public static readonly Type[] VehicleTypes = { typeof(Vehicle), typeof(Car), typeof(Motorbike), typeof(Truck) };
        
        public enum eVehicleTypes
        {
            Car = 1,
            Motorbike,
            Truck
        }
    }
}
