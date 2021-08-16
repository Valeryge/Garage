using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum LicenseType
        {
            AA, BB, A, B1
        }

        public LicenseType m_LicenseType;
        public int m_EngineVolume;

        public Motorcycle()
        {

        }

    }
}
