﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homepageproject
{
    public class CustomerNewClass
    {
        public string Name { get; set; }
       

        // Constructor to initialize data
        public CustomerNewClass(string name)
        {
            Name = name;
           
        }

        public override string ToString()
        {
            return $"name :{Name}\n";
        }
    }
}
