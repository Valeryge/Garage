using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) 
            : base(i_Message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public float MaxValue
        { 
            get { return m_MaxValue; } 
        }
    }
}
