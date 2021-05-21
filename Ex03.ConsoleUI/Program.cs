using System;
using System.Collections.Generic;
using System.Text;
using ConsoleUI;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            GarageUIManager Instance = new GarageUIManager();
            Instance.GarageManager();
            Console.Read();
        }
    }
}
