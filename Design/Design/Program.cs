using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CameraAPI;


// 
// This program is a badly written one. It has strong coupling between objects, no interfaces and no apparent designpatterns implemented.
// The program simulates a command-central, which can start and stop the surveillance cameras connected to it.
// Every camera is represented by a camera class, and in this program there are two types, indoor cameras and outdoor cameras.
// The cameras itself has different implementations, the outdoor cameras also has an lamp that must be handled. 
// 
//
// Camera settings:
//
// #Indoors 
// - Sound ON
// - Light OFF
// - Motion detect OFF
// - Filter OFF
//
// #Outdoors
// - Sound OFF
// - Light ON
// - Motion detect ON
// - Filter ON
//
// ASSIGNMENT
// -----------------------------
//  The goal is to redo the classes below - EXCEPT the camera-API!
//  You need to find a way to use design-patterns that decouple the strong relationship these classes have. 
//  *The user wants an convenient way (maybe by user input) to pick what cameras to use (camera - TYPE) and attach them to the Monitor system. 
//   This means using some kind of Creational pattern.
//  *The user only need one type of camera, indoor or outdoor
//  *The user want the feature to add and remove cameras from the monitor
//  *The user want to be able to send an signal to start or stop the cameras
//  
//


namespace Design
{

    public class Program
    {


        static void Main(string[] args)
        {
            //EXAMPLE

            // An instance of the monitor system

            CameraMonitor mon = new CameraMonitor();

            string[] intMenuArray = { "1", "2", "3", "4", "5", "6" };

            Console.WriteLine("**** THIS IS FACTORY DESIGN PATTERN IMPLEMENTATION ******");
            Console.WriteLine("**** SELECT THE CORRESPONDING NUMBER WHAT YOU WANT TO DO ******");
            Console.WriteLine("**** 1. Add OutDoor Camera ******");
            Console.WriteLine("**** 2. Add InDoor Camera ******");
            Console.WriteLine("**** 3. Remove a Camera ******");
            Console.WriteLine("**** 4. Start the Cameras ******");
            Console.WriteLine("**** 5. Stop the Cameras ******");
            Console.WriteLine("**** 6. Exit the portal ******");


            Console.Write("\nWhat you want do: ");
            string userInput = Console.ReadLine();

            // Checking if userInput is correct
            int pos = Array.IndexOf(intMenuArray, userInput);
            while (pos == -1)
            {
                Console.Write("InValid input! Enter [1-6] only, What you want do: ");
                userInput = Console.ReadLine();
                pos = Array.IndexOf(intMenuArray, userInput);
            }
            

            int cameraCount = 0;
            //List<Tuple<ICamera, string>> tempList = new List<Tuple<ICamera, string>>();
            //CameraFactory factory = new ConcreteCameraFactory();

            //creating temporary outdoor and indoor cameras lists to use it in only remove but not attaching to monitor.
            //List<OutDoorCamera> tempOutDoorCam = new List<OutDoorCamera>();
            //List<IndoorCamera> tempIndoorCam = new List<IndoorCamera>();

            while (userInput != "6")
            {

                // interface instead :

                if (userInput == "1")
                {                    
                    cameraCount++;

                    ICamera outdoor = mon.factory.CreateCamera("Outdoor", cameraCount);
                                      
                    //OutDoorCamera oc = new OutDoorCamera(cameraCount);
                    mon.AttachCamera(outdoor);
                    Console.WriteLine("Outdoor camera added successfully!");

                }

                if (userInput == "2")
                {
                    cameraCount++;
                    ICamera indoor = mon.factory.CreateCamera("Indoor", cameraCount);
                    
                    //IndoorCamera ic = new IndoorCamera(cameraCount);
                    mon.AttachCamera(indoor);
                    Console.WriteLine("Indoor camera added successfully!");
                }

                if (userInput == "3")
                {
                    
                    int camCount = mon._cameraList.Count;
                    
                    if (camCount > 0)
                    {                        
                        mon.RemoveCamera(mon._cameraList[camCount - 1]);
                        Console.WriteLine("Last added camera removed successfully!");
                    }
                    else
                        Console.WriteLine("No Camera left!");

                }                 


                if (userInput == "4")
                {                    
                    mon.StartCameras();
                    Console.WriteLine("\n All Cameras started successfully!");
                }

                if (userInput == "5")
                {                    
                    mon.StopCameras();
                    Console.WriteLine("\n All Cameras stopped successfully!");
                }

                Console.Write("\nWhat you want do: ");
                userInput = Console.ReadLine();

                // Checking if userInput is correct
                pos = Array.IndexOf(intMenuArray, userInput);
                while (pos == -1)
                {
                    Console.Write("InValid input! Enter [1-7] only, What you want do: ");
                    userInput = Console.ReadLine();
                    pos = Array.IndexOf(intMenuArray, userInput);
                }
            }


        }



    }

}



