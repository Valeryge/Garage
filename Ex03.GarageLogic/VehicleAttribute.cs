using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleAttribute
    {
        string m_Name;
        string m_Label;
        Type m_Type;

        public VehicleAttribute(string name, string label,Type type)
        {
            m_Name = name;
            m_Label = label;
            m_Type = type;
        }
    }
}
