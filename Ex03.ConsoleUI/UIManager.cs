using System;
using System.Text;
using System.Reflection.Emit;
using Ex03.GarageLogic;


namespace ConsoleUI
{

    class GarageUIManager
    {


        private StringBuilder buildMenu()
        {
            const k_MaxNumberOfCharsIn 120;
            int i = 0;
            string[] vhecleNames = Enum.GetNames(typeof(eMenuOptions));
            StringBuilder menuToPrint = new stringBuilder(k_MaxNumberOfCharsIn); // maybe change 120 to const for readabilty
            foreach (int Value in Enum.GetValues(typeof(VehicleCreator.eVehicleType)))
            {
                menuToPrint.AppendLine("For {0} press {1} ", names[i++], Value);
            }

            return menuToPrint;
        }

        public void GarageManager()
        {
            bool managerIsActive = true;
            GarageLogicManager garageInstance = GarageLogicManager.Garage;

            while (managerIsActive)
            {
                Console.WriteLine(buildMenu()); // add stringBuilder
                int chosenCase = int.Parse(Console.ReadLine());

                switch (chosenCase)
                {
                    case (int)eMenuOptions.EnterNewVehicle:
                        {
                            bool ChoseValidOption = letUserChooseCarOption(garageInstance);
                            if (ChoseValidOption)
                            {
                                Console.WriteLine("Please enter vehicle serial:");
                                string carSerialInput = Console.ReadLine();
                                Vehicle toEnterVehicle = null;
                                if (garageInstance.GarageDictionary.TryGetValue(carSerialInput, out toEnterVehicle)) { }
                                else
                                {
                                    toEnterVehicle = VehicleCreator.CreateVehicle(1);
                                    garageInstance.GarageDictionary.Add(carSerialInput, toEnterVehicle);
                                }

                                setRequiredInputs(toEnterVehicle);
                            }

                            break;
                        }
                    case (int)eMenuOptions.DisplayAllVehiclesByAttribute:
                        {
                            DisplayAllVehiclesInCurrentStatus(garageInstance);
                            break;
                        }
                    case (int)eMenuOptions.ChangeCarStatus:
                        {

                            break;
                        }
                    case (int)eMenuOptions.InflateWheelsToMaximum:
                        {
                            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to inflate it's wheels");
                            string carSerial = Console.ReadLine();
                            garageInstance.InflateWheels(carSerial);
                            break;
                        }
                    case (int)eMenuOptions.FillPetrolToVehicle:
                        {
                            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to petrol in");
                            string carSerial = Console.ReadLine();
                            Console.WriteLine("Enter the type of petrol to fill");
                            string petrolType = Console.ReadLine();
                            Console.WriteLine("Enter amount of petrol to fill");
                            float petrolAmount = float.Parse(Console.ReadLine());
                            garageInstance.FillPetrol(carSerial, petrolType, petrolAmount);
                            break;
                        }
                    case (int)eMenuOptions.ChargeElectricVehicle:
                        {
                            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to charge");
                            string carSerial = Console.ReadLine();
                            Console.WriteLine("Enter amount of minutes to charge into the vehicle");
                            float minutesAmount = float.Parse(Console.ReadLine());
                            garageInstance.ChargeElectricity(carSerial, minutesAmount);
                            break;
                        }
                    case (int)eMenuOptions.DisplayAllInfoOfVehicle:
                        {
                            Console.WriteLine("Enter the serial of the car which you want to display all information of");
                            string carSerial = Console.ReadLine();
                            Vehicle toBeDisplayed = null;
                            bool vehicleExists = garageInstance.GarageDictionary.TryGetValue(carSerial, out toBeDisplayed);
                            Console.WriteLine(toBeDisplayed.ToString());
                            break;
                        }
                    case (int)eMenuOptions.ExitProgram:
                        {
                            managerIsActive = false;
                            break;
                        }

                }
            }
        }

       private void askUserForVehicleStatus()
        {
            int i = 0;
            string[] statusNames = Enum.GetNames(typeof(Vehicle.eGarageStatus));
            StringBuilder optionsToPrint = new stringBuilder();
            optionsToPrint.AppendLine("Please enter numbers according to the options below {0} you can chose multiple values(separated with a space ends with new line):", Environment.NewLine)
            foreach (int statuse in Enum.GetValues(typeof(Vehicle.eGarageStatus)))
            {
                optionsToPrint.AppendFormat("For {0} press {1} ", names[i++], Value, Environment.NewLine);
            }

            Console.WriteLine(optionsToPrint);
        }

        public void DisplayAllVehiclesInCurrentStatus(GarageLogicManager i_Garage)
        {
            int i = 0;
            askUserForVehicleStatus();
            int[] vehicleStatusToDisplay = new int[Enum.GetNames(typeof(Vehicle.eGarageStatus)).Length];
            string choosenOption = Console.ReadLine();
            foreach (char option in choosenOption)
            {
                if (char.IsDigit(option))
                {
                    vehicleStatusToDisplay[i++] = (int)option;
                }
                else
                {
                    if (option != ' ')
                    {
                        throw new FormatException("enter only digits according to the option that was given");
                    }
                }
            }

            Console.WriteLine(GetListOfVehicleByStatus(vehicleStatusToDisplay));
        }

        private bool letUserChooseCarOption(GarageLogicManager garageInstance)
        {
            int userOption = 0;
            string[] VehicleTypes = Enum.GetNames(typeof(VehicleCreator.eVehicleTypes));

            Console.WriteLine("Please choose 1 of the following options or enter '0' for none of them");
            for (int index = 1; index <= VehicleTypes.Length; index++)
            {
                Console.WriteLine(index + ". " + VehicleTypes[index - 1]);
            }

            return userOption != 0;
        }

        private bool letUserChooseCarOption(GarageLogicManager garageInstance)
        {
            int userOption = 0;
            string[] VehicleTypes = Enum.GetNames(typeof(VehicleCreator.eVehicleTypes));

            Console.WriteLine("Please choose 1 of the following options or enter '0' for none of them");
            for (int index = 1; index <= VehicleTypes.Length; index++)
            {
                Console.WriteLine(index + ". " + VehicleTypes[index - 1]);
            }

            return userOption != 0;
        }

        private void setRequiredInputs(Vehicle toEnterVehicle)
        {
            int numberOfVehicles = VehicleCreator.VehicleTypes.Length - 1;
        }


        //public Vehicle GetInputForVehicle(int i_InputForVehicle)
        //{
        //    Vehicle vehicle = new Car();
        //    bool isElctric = true;
        //    switch (i_InputForVehicle)
        //    {
        //        case (int)GarageLogicManager.eVehicleType.ElectricCar:
        //            vehicle = MakeCar(isElctric);
        //            break;
        //        case (int)GarageLogicManager.eVehicleType.PetrolCar:
        //            vehicle = MakeCar(!isElctric);
        //            break;
        //        case (int)GarageLogicManager.eVehicleType.ElectricBike:
        //            vehicle = MakeBike(isElctric);
        //            break;
        //        case (int)GarageLogicManager.eVehicleType.PetrolBike:
        //            vehicle = MakeBike(!isElctric);
        //            break;
        //        case (int)GarageLogicManager.eVehicleType.Truck:
        //            vehicle = MakeTruck();
        //            break;
        //    }

        //    return vehicle;
        //}

        //private string getPhoneNumber()
        //{
        //    string phoneNumber = Console.ReadLine();
        //    bool validPhoneNumber = true;
        //    foreach(char c in phoneNumber)
        //    {
        //        if(!char.IsDigit(c))
        //        {
        //            validPhoneNumber = false;
        //            break;
        //        }
        //    }

        //    return validPhoneNumber ? phoneNumber : throw new Exception("phone number is not valid");
        //}
        //public void GetBasicAttributes(out string o_BrandName, out string o_OwnerName, out string o_PhoneNumber, out  string o_SerialNumber, out float o_EnergyLeft)
        //{
        //    Console.WriteLine("please enter owner name:");
        //    o_OwnerName = Console.ReadLine();

        //    Console.WriteLine("please enter brand name:");
        //    o_BrandName = Console.ReadLine();

        //    Console.WriteLine("Please enter customer phone number:");
        //    o_PhoneNumber = getPhoneNumber(); // can throwing error

        //    Console.WriteLine("Please enter vehicle serial number:");
        //    o_SerialNumber = Console.ReadLine();

        //    Console.WriteLine("Please enter remaining energy: ");
        //    float.TryParse(Console.ReadLine(), out o_EnergyLeft);
        //}

        //private void getElectricAttributes(out float o_RemainingBatteryHours)
        //{
        //    Console.WriteLine("Please enter the remaining battery hours left:");
        //    float.TryParse(Console.ReadLine(),out o_RemainingBatteryHours);
        //}

        //private void getPetrolAttributes(out int o_FuelType , out float o_CurrentFuelLitters)
        //{
        //    Console.WriteLine("Please enter fuel type: 1 - Soler, 2 - 95 , 3 - 96 , 4 - 98:");
        //    int.TryParse(Console.ReadLine(), out o_FuelType);

        //    Console.WriteLine("Please enter current litter of fuel in the tank"); // need to throe out pf range exception here
        //    float.TryParse(Console.ReadLine(), out o_CurrentFuelLitters);
        //}

        //private void getWheelAttributes(out string o_WheelBrand, out float o_CurrentAirPressure)
        //{
        //    Console.WriteLine("Please enter wheel brand");
        //    o_WheelBrand = Console.ReadLine();

        //    Console.WriteLine("Please enter wheels current air pressure:"); // needs throw outofrange ex if needed
        //    float.TryParse(Console.ReadLine(), out o_CurrentAirPressure);
        //}

        //public Car MakeCar(bool i_IsElectric)
        //{

        //    string brandName, ownerName, phoneNumber, serialNumber;
        //    float energyLeft;
        //    GetBasicAttributes(out brandName, out ownerName, out phoneNumber, out serialNumber, out energyLeft);

        //    Console.WriteLine("Please enter car color: 1 - Red, 2 - Silver , 3 - White , 4 - Black");
        //    int.TryParse(Console.ReadLine() ,out int CarColor);

        //    Console.WriteLine("Please enter numbers of doors(2 - 5): ");
        //    int.TryParse(Console.ReadLine(), out int NumberOfDoors);

        //    getWheelAttributes(out string wheelBrand, out float currentAirPressure);

        //    if(i_IsElectric)
        //    {
        //        getElectricAttributes(out float remainingBatteryHours);
        //    }

        //    else
        //    {
        //        getPetrolAttributes(out int fuelType , out float currentFuelLitters);
        //    }

    }


    enum eMenuOptions
    {
        EnterNewVehicle = 1, //v/
        DisplayAllVehiclesByAttribute,
        ChangeCarStatus,
        InflateWheelsToMaximum, //v//
        FillPetrolToVehicle, //v//
        ChargeElectricVehicle, //v//
        DisplayAllInfoOfVehicle, //v//
        ExitProgram //check
    }
}
