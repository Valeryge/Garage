using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GarageManager
    {
        public struct CustomerCard
        {
            Vehicle vehicle;
            string customerName;
            string phoneNumber;
            RepairState vehicleState;
        }

        public enum RepairState
        {
            InProgress = 0,
            Fixed = 1,
            Paid = 2
        }

        public Dictionary<string, CustomerCard> m_CustomerCards = new Dictionary<string, CustomerCard>();

           

    }   
}
