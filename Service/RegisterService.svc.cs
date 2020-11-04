using Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RegisterService : IRegisterService
    {
        private List<Patient.Patient> patients = new List<Patient.Patient>();
        private List<Patient.PatientContact> patientContacts = new List<PatientContact>();

        public void AddPatient(Patient.Patient patient)
        {
            patients.Add(patient);
        }

        public void AddContact(PatientContact contact)
        {
            patientContacts.Add(contact);
        }

        public IEnumerable<Patient.Patient> GetPatients()
        {
            return patients.ToList();
        }

    }
}
