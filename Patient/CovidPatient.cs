﻿using System;
using System.Runtime.Serialization;

namespace Patient
{
    [DataContract]
    public class CovidPatient
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public DateTime FirstSymptoms { get; set; }

        [DataMember]
        public DateTime TestDate { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public Contact PatientContact { get; set; }

        public override string ToString()
        {
            return $"";
        }

    }
}
