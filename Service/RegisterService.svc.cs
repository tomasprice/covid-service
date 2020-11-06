using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RegisterService : IRegisterService
    {
        private readonly List<Patient.CovidPatient> Patients = new List<Patient.CovidPatient>();

        public void AddPatient(Patient.CovidPatient patient)
        {
            Patients.Add(patient);
        }

        public IEnumerable<Patient.CovidPatient> EndSession()
        {
            return Patients.ToList();
        }

        public IEnumerable<Patient.CovidPatient> GetPatients()
        {
            return Patients.ToList();
        }

    }
}
