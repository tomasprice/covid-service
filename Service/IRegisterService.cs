using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    [ServiceContract]
    public interface IRegisterService
    {
        [OperationContract]
        void AddPatient(Patient.Patient patient);

        [OperationContract]
        IEnumerable<Patient.Patient> GetPatients();

        [OperationContract]
        void AddContact(Patient.PatientContact contact);
    }
}
