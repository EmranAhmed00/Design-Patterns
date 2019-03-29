using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class IndoorCamera : ICamera
    {
        
        IndoorCameraFacade IndoorFacade = new IndoorCameraFacade();
         
        private readonly int _id;

        public IndoorCamera(int id)
        {
            _id = id;
        }

        // CurrentState = true (start all cameras) && CurrentState = false (stop all cameras)
        public void Update(ICameraCentral s)
        {
            if (s.GetState().CurrentState)

            {
                Console.WriteLine("\nInDoor Camera with Id: " + _id.ToString() + " is starting");
                IndoorFacade.Start();

            }
            else
            {
                Console.WriteLine("\nInDoor Camera with Id: " + _id.ToString() + " is stopping");
                IndoorFacade.Stop();
            }
        }
    }

}
