﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime ContactDate { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
