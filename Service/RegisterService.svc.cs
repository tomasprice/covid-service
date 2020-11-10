using Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RegisterService : IRegisterService
    {
        private readonly List<Patient.CovidPatient> Patients = new List<Patient.CovidPatient>();

        public void AddPatient(Patient.CovidPatient patient)
        {
            Patients.Add(patient);
        }

        public void AddContact(Contact contact)
        {
            var indexLast = Patients.Count() - 1;
            Patients[indexLast].PatientContact.Add(contact);
        }

        public Patient.CovidPatient GetPatient()
        {
            return Patients.LastOrDefault();
        }

        public IEnumerable<Patient.CovidPatient> EndSession()
        {
            return Patients.ToList();
        }
    }
}
