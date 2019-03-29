using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns

{
    class OutdoorCamera : ICamera
    {
       

        OutdoorCameraFacade outdoorFacade = new OutdoorCameraFacade();

        private readonly int _id;

        public OutdoorCamera(int id)
        {
            _id = id;
        }

        public void Update(ICameraCentral s)
        {
            if (s.GetState().CurrentState)
            {
                Console.WriteLine("\nOutDoor Camera with Id: " + _id.ToString() + " is starting");

                outdoorFacade.Start();
            }
            else
            {
                Console.WriteLine("\nOutDoor Camera with Id: " + _id.ToString() + " is stopping");

                outdoorFacade.Stop();
            }
        }
    }

}
