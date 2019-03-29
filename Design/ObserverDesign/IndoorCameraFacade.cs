using CameraAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // ************** Facade Design Pattern.**************

    public class IndoorCameraFacade
    {
        CameraDriver drive = new CameraDriver();
        ImageProcessor iProcessor = new ImageProcessor();
        SoundProcessor sProcessor = new SoundProcessor();
    
     

        public void Start()
        {
            drive.ConnectCamera();
            iProcessor.StartImageReceiver();
            sProcessor.StartSoundReceiver();
            sProcessor.SetVolume(0.5f);
        }
          

        public void Stop()
        {
            drive.DisconnectCamera();
            iProcessor.StopImageReceiver();
            sProcessor.StopSoundReceiver();
           
        }
    }
}
