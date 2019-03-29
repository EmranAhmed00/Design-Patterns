using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // ************** Factory Design Pattern.**************

    public class Factory 
        {
            public static ICamera CreateCamera(string Camera, int Id)
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
