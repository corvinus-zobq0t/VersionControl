﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroszimulacio_week9.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender gender { get; set; }
        public int NbrOfChildren { get; set; }
        public bool IsAlive { get; set; }
        public Person()
        {
            IsAlive = true;
        }
    }
}