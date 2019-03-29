using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraAPI;

namespace DesignPatterns
{
 
    // ************** Observer Design Pattern.**************
   

   public interface ICameraState //IState
    {
        bool CurrentState { get; set; }
    }

    public interface ICameraCentral // ISubject
    {
        void Notify();
        void Attach(ICamera camera);
        void Detach(ICamera camera);
        ICameraState GetState();
        void SetState(ICameraState status);
    }

    public interface ICamera // IObserver
    {
        void Update(ICameraCentral s);
    }


    class CameraCentral : ICameraCentral
    {
        public readonly List<ICamera> _cameraList;

        private CameraState _cameraState;

        public CameraCentral()
        {
            _cameraList = new List<ICamera>();
            _cameraState = new CameraState();
        }

        public void Notify()
        {
            foreach (var o in _cameraList)
                o.Update(this);
        }

        public void Attach(ICamera o)
        {
            _cameraList.Add(o);
        }

        public void Detach(ICamera o)
        {
            _cameraList.Remove(o);
        }

        public ICameraState GetState()
        {
            return _cameraState;
        }

        public void SetState(ICameraState s)
        {
            _cameraState = s as CameraState;
        }

    }
}
