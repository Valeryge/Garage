using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GarageManager;

namespace Ex03.GarageLogic
{
    class Customer
    {
        Vehicle m_Vehicle;
        string m_CustomerName;
        string m_PhoneNumber;
        RepairState m_VehicleState;



        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }


    }
}
