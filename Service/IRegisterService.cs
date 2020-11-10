using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IRegisterService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void AddPatient(Patient.CovidPatient patient);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void AddContact(Patient.Contact contact);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Patient.CovidPatient GetPatient();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        IEnumerable<Patient.CovidPatient> EndSession();
    }
}
