using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Factory;
using CameraAPI;

namespace Design
{
    /// <summary>
    /// Camera Monitor is holding to many references to other classes, its strongly coupled.
    /// Look at some designpatterns that solve one-to-many relationships. 
    /// </summary>
    public class CameraMonitor
    {

        public CameraFactory factory = new ConcreteCameraFactory();

        public readonly List<ICamera> _cameraList;

        public CameraMonitor()
        {
            this._cameraList = new List<ICamera>();
        }

        public void AttachCamera(ICamera camera)
        {
            _cameraList.Add(camera);

        }

        public void RemoveCamera(ICamera camera)
        {
            _cameraList.Remove(camera);     
        }

        public void StartCameras()
        {

            foreach (ICamera camera in _cameraList)            
                camera.Start();
        }

        public void StopCameras()
        {

            foreach (ICamera camera in _cameraList)
                camera.Stop();
        }

    }

}


