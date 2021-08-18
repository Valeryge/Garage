using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private Vehicle m_Vehicle;
        private string m_CustomerName;
        private string m_PhoneNumber;
        private RepairState m_VehicleState;

        public RepairState VehicleState
        {
            get { return m_VehicleState; }
            set {
                if (Enum.IsDefined(typeof(RepairState), value)) {
                    m_VehicleState = value;
                } else
                {
                    throw new ArgumentException("Not a defined repair state");
                }
            }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public enum RepairState
        {
            InProgress = 1,
            Fixed = 2,
            Paid = 3
        }

        public CustomerCard(Vehicle i_Vehicle, string i_CustomerName, string i_PhoneNumber)
        {
            m_CustomerName = i_CustomerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
            m_VehicleState = RepairState.InProgress;
        }
    }
}
