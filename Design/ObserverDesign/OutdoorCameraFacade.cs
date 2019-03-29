using CameraAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // ************** Facade Design Pattern.**************

    public class OutdoorCameraFacade
    {
        
        CameraDriver drive = new CameraDriver();
        ImageProcessor iProcessor = new ImageProcessor();
        SoundProcessor sProcessor = new SoundProcessor();
        CameraLight cLight = new CameraLight();
        MotionSensor mSensor = new MotionSensor();

        public void Start()
        {
            drive.ConnectCamera();
            iProcessor.StartImageReceiver();
            iProcessor.EnableFilter();
            cLight.StartLight();
            mSensor.StartMotionSensor();
        }
         public void Stop()
        {
            drive.DisconnectCamera();
            iProcessor.StopImageReceiver();
            cLight.StopLight();
            mSensor.StopMotionSensor();
        }
    }
}

