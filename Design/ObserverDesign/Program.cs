using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    class Program
    {
        static void Main(string[] args)
        {
            
            // An instance of the monitor system

            CameraCentral camCentral = new CameraCentral();

            string[] intMenuArray = { "1", "2", "3", "4", "5", "6", "7" };
           

            Console.WriteLine("***********  DESIGN PATTERN ************");
            Console.WriteLine("****** CAMERA MONITOR APP ************");
            Console.WriteLine("\n \n**** 1. Add OutDoor Camera ******");
            Console.WriteLine("**** 2. Add InDoor Camera ******");
            Console.WriteLine("**** 3. Remove a Camera ******");
            Console.WriteLine("**** 4. Start the Cameras ******");
            Console.WriteLine("**** 5. Stop the Cameras ******");
            Console.WriteLine("**** 6. Check the current status of Cameras (On/Off) ******");
            Console.WriteLine("**** 7. Exit the portal ******");


            Console.Write("\nSelect from the Monitor: ");
            string userInput = Console.ReadLine();

            // Checking if userInput is correct
            int pos = Array.IndexOf(intMenuArray, userInput);
            while (pos == -1)
            {
                Console.Write("InValid input! Enter digit [1-7] only : ");
                userInput = Console.ReadLine();
                pos = Array.IndexOf(intMenuArray, userInput);
            }

            int cameraCount = 0;

            while (userInput != "7")
            {

                // interface instead :

                if (userInput == "1")
                {
                    cameraCount++;
                    ICamera o = Factory.CreateCamera("Outdoor", cameraCount);
                    camCentral.Attach(o);
                    Console.WriteLine("Outdoor camera added successfully!");

                }

                if (userInput == "2")
                {
                    cameraCount++;
                    ICamera i = Factory.CreateCamera("Indoor", cameraCount);
                    camCentral.Attach(i);
                    Console.WriteLine("Indoor camera added successfully!");
                }

                if (userInput == "3")
                {

                    int camCount = camCentral._cameraList.Count;

                    if (camCount > 0)
                    {
                        camCentral.Detach(camCentral._cameraList[camCount - 1]);
                        Console.WriteLine("Last added camera removed successfully!");
                    }
                    else
                        Console.WriteLine("No Camera left!");

                }

                // CurrentState = true (start all cameras) && CurrentState = false (stop all cameras)
                if (userInput == "4")
                {
                    ICameraState status = new CameraState();
                    status.CurrentState = true;
                    camCentral.SetState(status);
                    camCentral.Notify();

                    Console.WriteLine("\n All Cameras started successfully!");
                }


                if (userInput == "5")
                {
                    ICameraState status = new CameraState();
                    status.CurrentState = false;
                    camCentral.SetState(status);
                    camCentral.Notify();
                    Console.WriteLine("\n All Cameras stopped successfully!");
                }

                if (userInput == "6")
                {
                    if (camCentral.GetState().CurrentState)
                        Console.WriteLine("\n All Cameras are ON!");
                    else
                        Console.WriteLine("\n All Cameras are OFF!");
                }

                Console.Write("\nSelect from the Monitor: ");
                userInput = Console.ReadLine();

                // Checking if userInput is correct
                pos = Array.IndexOf(intMenuArray, userInput);
                while (pos == -1)
                {
                    Console.Write("InValid input! Enter digit [1-7] only, Select from the Monitor: ");
                    userInput = Console.ReadLine();
                    pos = Array.IndexOf(intMenuArray, userInput);
                }
            }

           
        }
    }
}


