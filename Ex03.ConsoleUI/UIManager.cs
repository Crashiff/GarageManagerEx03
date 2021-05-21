using System;
using System.Text;
using Ex03.GarageLogic;


namespace ConsoleUI
{

    class GarageUIManager
    {
        public void GarageManager()
        {
            bool managerIsActive = true;
            GarageLogicManager garageInstance = GarageLogicManager.Garage;

            while (managerIsActive)
            {
                eMenuOptions chosenCase = getOptionInput();

                switch (chosenCase)
                {
                    case eMenuOptions.EnterNewVehicle:
                    {
                        enterNewVehicle(garageInstance);
                        break;
                    }
                    case eMenuOptions.DisplayAllVehiclesByAttribute:
                    {
                        DisplayAllVehiclesInCurrentStatus(garageInstance);
                        break;
                    }
                    case eMenuOptions.ChangeCarStatus:
                    {
                        changeACarsStatus(garageInstance);
                        break;
                    }
                    case eMenuOptions.InflateWheelsToMaximum:
                    {
                        inflateCarsWheelsToMaximum(garageInstance);
                        break;
                    }
                    case eMenuOptions.FillPetrolToVehicle:
                    {
                        fillPetrolToAVehicle(garageInstance);
                        break;
                    }
                    case eMenuOptions.ChargeElectricVehicle:
                    {
                        chargeACarWithElectricity(garageInstance);
                        break;
                    }
                    case eMenuOptions.DisplayAllInfoOfVehicle:
                    {
                        displayAllInformationOfSpecifiedVehicle(garageInstance);
                        break;
                    }
                    case eMenuOptions.ExitProgram:
                    {
                        managerIsActive = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid menu option");
                        break;
                    }

                }
            }
        }

        private void enterNewVehicle(GarageLogicManager i_GarageInstance)
        {
            bool codeSectionCompleted = false;
            VehicleCreator.eVehicleTypes chosenVehicleOption = letUserChooseCarOption(); ;
            if (Enum.IsDefined(typeof(VehicleCreator.eVehicleTypes), chosenVehicleOption))
            {
                Console.WriteLine("Please enter vehicle serial:");
                string carSerialInput = Console.ReadLine();
                Vehicle toEnterVehicle = null;
                if (i_GarageInstance.GarageDictionary.TryGetValue(carSerialInput, out toEnterVehicle)) { }
                else
                {
                    toEnterVehicle = VehicleCreator.CreateVehicle(chosenVehicleOption);
                    i_GarageInstance.GarageDictionary.Add(carSerialInput, toEnterVehicle);
                }

                setBaseProperties(toEnterVehicle, carSerialInput);
                setRequiredInputs(toEnterVehicle);
            }
        }

        private void changeACarsStatus(GarageLogicManager i_GarageInstance)
        {
            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to inflate it's wheels");
            string carSerial = Console.ReadLine();
            Console.WriteLine("Please enter the new status of the vehicle (InRepair, Repaired, RepairedAndPaid): ");
            string userInput = Console.ReadLine();
            try
            {
                i_GarageInstance.ChangeStatus(carSerial, userInput);
            }
            catch (ArgumentException badArgumentException)
            {
                Console.WriteLine(badArgumentException.Message);
            }

        }

        private void inflateCarsWheelsToMaximum(GarageLogicManager i_GarageInstance)
        {
            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to inflate it's wheels");
            string carSerial = Console.ReadLine();
            try
            {
                i_GarageInstance.InflateWheels(carSerial);
            }
            catch (Exception carDoesntExistException)
            {
                Console.WriteLine(carDoesntExistException);
            }
        }

        private void fillPetrolToAVehicle(GarageLogicManager i_GarageInstance)
        {
            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to petrol in");
            string carSerial = Console.ReadLine();
            Console.WriteLine("Enter the type of petrol to fill");
            string petrolType = Console.ReadLine();
            Console.WriteLine("Enter amount of petrol to fill");
            float petrolAmount = float.Parse(Console.ReadLine());

            try
            {
                i_GarageInstance.FillPetrol(carSerial, petrolType, petrolAmount);
            }
            catch (FormatException parseFailException)
            {
                Console.WriteLine(parseFailException);
            }
            catch (Exception relevantError)
            {
                Console.WriteLine(relevantError);
            }

        }

        private void chargeACarWithElectricity(GarageLogicManager i_GarageInstance)
        {
            Console.WriteLine("Enter the 'Serial' of the vehicle which you want to charge");
            string carSerial = Console.ReadLine();
            Console.WriteLine("Enter amount of minutes to charge into the vehicle");
            string minutesAmount = Console.ReadLine();
            try
            {
                i_GarageInstance.ChargeElectricity(carSerial, minutesAmount);
            }
            catch (FormatException parseFailException)
            {
                Console.WriteLine(parseFailException);
            }
            catch (Exception otherException)
            {
                Console.WriteLine(otherException);
            }

        }

        private void askUserForVehicleStatus()
        {
            int i = 0;
            string[] statusNames = Enum.GetNames(typeof(Vehicle.eGarageStatus));
            StringBuilder optionsToPrint = new StringBuilder();
            optionsToPrint.AppendFormat(
                "Please enter numbers according to the options below {0} you can chose multiple values(separated with a space ends with new line):{0}",
                Environment.NewLine);
            foreach (int statuse in Enum.GetValues(typeof(Vehicle.eGarageStatus)))
            {
                optionsToPrint.AppendFormat("For {0} press {1}{2}", statusNames[i++], statuse, Environment.NewLine);
            }

            Console.WriteLine(optionsToPrint);
        }

        public void DisplayAllVehiclesInCurrentStatus(GarageLogicManager i_GarageInstance)
        {
            int i = 0;
            askUserForVehicleStatus();
            int[] vehicleStatusToDisplay = new int[Enum.GetNames(typeof(Vehicle.eGarageStatus)).Length];
            string choosenOption = Console.ReadLine();
            foreach (char option in choosenOption)
            {
                if (char.IsDigit(option))
                {
                    vehicleStatusToDisplay[i++] = (int)char.GetNumericValue(option);
                }
                else
                {
                    if (option != ' ')
                    {
                        throw new FormatException("enter only digits according to the option that was given");
                    }
                }
            }

            Console.WriteLine(i_GarageInstance.GetListOfVehicleByStatus(vehicleStatusToDisplay));
        }

        private void displayAllInformationOfSpecifiedVehicle(GarageLogicManager i_GarageInstance)
        {
            Console.WriteLine("Enter the serial of the car which you want to display all information of");
            string carSerial = Console.ReadLine();
            Vehicle toBeDisplayed = null;
            bool vehicleExists = i_GarageInstance.GarageDictionary.TryGetValue(carSerial, out toBeDisplayed);
            Console.WriteLine(toBeDisplayed.ToString());
        }

        private VehicleCreator.eVehicleTypes letUserChooseCarOption()
        {
            VehicleCreator.eVehicleTypes userOption = 0;
            string[] VehicleTypes = Enum.GetNames(typeof(VehicleCreator.eVehicleTypes));

            Console.WriteLine("Please choose One of the following options by its corresponding number or any other value for none of them");
            for (int index = 1; index <= VehicleTypes.Length; index++)
            {
                Console.Write(index + ".");
                printSpacelessPhraseByUppercase(VehicleTypes[index - 1]);
            }

            userOption = (VehicleCreator.eVehicleTypes)Enum.Parse(typeof(VehicleCreator.eVehicleTypes), Console.ReadLine());
            return userOption;
        }

        private void printSpacelessPhraseByUppercase(string I_PhraseToPrint)
        {
            for (int i = 0; i < I_PhraseToPrint.Length; i++)
            {
                if (char.IsUpper(I_PhraseToPrint[i]))
                {
                    Console.Write(' ');
                }
                Console.Write(I_PhraseToPrint[i]);
            }
            Console.Write(Environment.NewLine);
        }

        private void setBaseProperties(Vehicle toEnterVehicle, string i_VehicleSerial)
        {
            Console.WriteLine("Please enter Owner Name");
            toEnterVehicle.OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter Owner Phone number");
            toEnterVehicle.OwnerPhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Vehicle Brand");
            toEnterVehicle.VehicleBrand = Console.ReadLine();

            toEnterVehicle.VehicleGarageStatus = Vehicle.eGarageStatus.InRepair;
            toEnterVehicle.VehicleSerial = i_VehicleSerial;
        }

        private void setRequiredInputs(Vehicle toEnterVehicle)
        {
            string[] VehicleTypes = toEnterVehicle.GetPropertiesNames();
            for (int propertyIndex = 0; propertyIndex < VehicleTypes.Length; propertyIndex++)
            {
                Console.Write("Please enter the vehicle's:");
                printSpacelessPhraseByUppercase(VehicleTypes[propertyIndex]);
                string propertyUserInput = Console.ReadLine();
                toEnterVehicle.UpdatePropertyByStringInputAndPropertyIndex(propertyUserInput, propertyIndex);
            }
        }

        private StringBuilder buildMenu()
        {
            int i = 0;
            const int k_MaxNumberOfCharsIn = 120;
            string[] menuOptions = Enum.GetNames(typeof(eMenuOptions));
            StringBuilder menuToPrint = new StringBuilder(k_MaxNumberOfCharsIn);
            foreach (int value in Enum.GetValues(typeof(eMenuOptions)))
            {
                menuToPrint.AppendFormat("For {0} press {1}{2}", menuOptions[i++], value, Environment.NewLine);
            }

            return menuToPrint;
        }

        private eMenuOptions getOptionInput()
        {
            eMenuOptions chosenOption = 0;

            while (!Enum.IsDefined(typeof(eMenuOptions), chosenOption))
            {
                try
                {
                    Console.WriteLine(buildMenu());
                    chosenOption = (eMenuOptions)Enum.Parse(typeof(eMenuOptions), Console.ReadLine());
                    if (!Enum.IsDefined(typeof(eMenuOptions), chosenOption))
                    {
                        throw new IndexOutOfRangeException("ERROR: Input is not in range of valid options, try again");
                    }

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ERROR: Invalid option input, try again");
                }
                catch (IndexOutOfRangeException rangeErrorException)
                {
                    Console.WriteLine(rangeErrorException.Message);
                }

            }

            return chosenOption;
        }
    }

    enum eMenuOptions
    {
        EnterNewVehicle = 1, 
        DisplayAllVehiclesByAttribute,
        ChangeCarStatus, //Completed//
        InflateWheelsToMaximum, //Completed//
        FillPetrolToVehicle, //Completed//
        ChargeElectricVehicle, //Completed//
        DisplayAllInfoOfVehicle, 
        ExitProgram //Completed//
    }
}
