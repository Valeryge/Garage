using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string m_Manufactor;
        float m_Pressure;
        float m_MaxPressure;

        public Wheel(float i_MaxPressure, string i_Manufactor)
        {
            m_MaxPressure = i_MaxPressure;
            m_Manufactor = i_Manufactor;
        }

        public void AddPressure(float i_PressureToAdd) 
        {
            m_Pressure = Math.Min(m_Pressure + i_PressureToAdd, m_MaxPressure);
        }

        public void SetPressureToMax()
        {
            m_Pressure = m_MaxPressure;
        }
    }
}
