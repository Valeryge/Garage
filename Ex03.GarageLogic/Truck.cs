﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool m_IsDangerSubstence;
        public float m_MaxWeight;

        GasEngine m_Engine;

        public Truck()
        {

        }
        public GasEngine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }
    }

}
