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
        IEnumerable<Patient.CovidPatient> GetPatients();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        IEnumerable<Patient.CovidPatient> EndSession();
    }
}
