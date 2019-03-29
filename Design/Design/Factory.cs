using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraAPI;


namespace Design
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface ICamera
    {
        // Gives the type of camera (indoor/outdoor); Useful in identification while removing
        string CameraType { get; }

        void Start();

        void Stop();

    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class OutdoorCamera : ICamera
    {
        CameraDriver CamDriver = new CameraDriver();
        ImageProcessor ImgP = new ImageProcessor();
        CameraLight CamLight = new CameraLight();
        MotionSensor MotSensor = new MotionSensor();

        public int Id;
        public string CameraType => "outdoor";

        public OutdoorCamera(int id)
        {
            Console.WriteLine("Outdoor camera with ID: " + id.ToString() + " is created!");

            this.Id = id;
        }

        public void Start()
        {
            Console.WriteLine("\nOutDoor Camera with Id: " + Id.ToString() + " is starting");
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            ImgP.EnableFilter();
            CamLight.StartLight();
            MotSensor.StartMotionSensor();

        }

        public void Stop()
        {
            Console.WriteLine("\nOutDoor Camera with Id: " + Id.ToString() + " is stopping");
            ImgP.StopImageReceiver();
            CamLight.StopLight();
            MotSensor.StopMotionSensor();
            CamDriver.DisconnectCamera();

        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class IndoorCamera : ICamera
    {
        CameraDriver CamDriver = new CameraDriver();
        ImageProcessor ImgP = new ImageProcessor();
        SoundProcessor SoundP = new SoundProcessor();

        public int Id;
        public string CameraType => "indoor";

        public IndoorCamera(int id)
        {
            Console.WriteLine("Indoor camera with ID: " + id.ToString() + " is created!");
            this.Id = id;
        }

        public void Start()
        {
            Console.WriteLine("\nInDoor Camera with Id: " + Id.ToString() + " is starting");
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            SoundP.StartSoundReceiver();
            SoundP.SetVolume(0.5f);

        }

        public void Stop()
        {
            Console.WriteLine("\nInDoor Camera with Id: " + Id.ToString() + " is stopping");
            ImgP.StopImageReceiver();
            SoundP.StopSoundReceiver();
            CamDriver.DisconnectCamera();

        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class CameraFactory
    {
        public abstract ICamera CreateCamera(string Camera, int Id);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCameraFactory : CameraFactory
    {
        public override ICamera CreateCamera(string Camera, int Id)
        {
            switch (Camera)
            {
                case "Outdoor":
                    return new OutdoorCamera(Id);
                case "Indoor":
                    return new IndoorCamera(Id);
                default:
                    throw new ApplicationException(string.Format("Camera '{0}' cannot be created", Camera));
            }
        }

    }
}
