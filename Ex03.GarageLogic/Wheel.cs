using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufactor;
        private float m_Pressure;
        private float m_MaxPressure;

        public float MaxPressure
        {
            get { return m_MaxPressure; }
            set { m_MaxPressure = value; }
        }

        public string Manufactor
        {
            get { return m_Manufactor; }
            set { m_Manufactor = value; }
        }

        public float Pressure
        {
            set
            {
                if (value <= m_MaxPressure)
                {
                    m_Pressure = value;
                } else
                {
                    throw new ValueOutOfRangeException(String.Format("Pressure cant be higher than {0}", MaxPressure), 0, MaxPressure);
                }
            }
        }

        public Wheel(float i_MaxPressure) 
        {
            m_MaxPressure = i_MaxPressure;
        }

        public void AddPressure(float i_PressureToAdd) 
        {
            m_Pressure = Math.Min(m_Pressure + i_PressureToAdd, m_MaxPressure);
        }

        public void SetPressureToMax()
        {
            m_Pressure = m_MaxPressure;
        }

        public string GetData()
        {
            string data = String.Format("Manufactor: {0}, Pressure: {1}, Max Pressure: {2}", m_Manufactor, m_Pressure, m_MaxPressure);

            return data;
        }
    }
}
