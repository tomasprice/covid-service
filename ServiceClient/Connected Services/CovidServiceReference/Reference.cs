﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceClient.CovidServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CovidServiceReference.IRegisterService", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IRegisterService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegisterService/AddPatient", ReplyAction="http://tempuri.org/IRegisterService/AddPatientResponse")]
        void AddPatient(Patient.CovidPatient patient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegisterService/AddPatient", ReplyAction="http://tempuri.org/IRegisterService/AddPatientResponse")]
        System.Threading.Tasks.Task AddPatientAsync(Patient.CovidPatient patient);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IRegisterService/GetPatients", ReplyAction="http://tempuri.org/IRegisterService/GetPatientsResponse")]
        Patient.CovidPatient[] GetPatients();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IRegisterService/GetPatients", ReplyAction="http://tempuri.org/IRegisterService/GetPatientsResponse")]
        System.Threading.Tasks.Task<Patient.CovidPatient[]> GetPatientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IRegisterService/EndSession", ReplyAction="http://tempuri.org/IRegisterService/EndSessionResponse")]
        Patient.CovidPatient[] EndSession();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IRegisterService/EndSession", ReplyAction="http://tempuri.org/IRegisterService/EndSessionResponse")]
        System.Threading.Tasks.Task<Patient.CovidPatient[]> EndSessionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegisterServiceChannel : ServiceClient.CovidServiceReference.IRegisterService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterServiceClient : System.ServiceModel.ClientBase<ServiceClient.CovidServiceReference.IRegisterService>, ServiceClient.CovidServiceReference.IRegisterService {
        
        public RegisterServiceClient() {
        }
        
        public RegisterServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegisterServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegisterServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegisterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddPatient(Patient.CovidPatient patient) {
            base.Channel.AddPatient(patient);
        }
        
        public System.Threading.Tasks.Task AddPatientAsync(Patient.CovidPatient patient) {
            return base.Channel.AddPatientAsync(patient);
        }
        
        public Patient.CovidPatient[] GetPatients() {
            return base.Channel.GetPatients();
        }
        
        public System.Threading.Tasks.Task<Patient.CovidPatient[]> GetPatientsAsync() {
            return base.Channel.GetPatientsAsync();
        }
        
        public Patient.CovidPatient[] EndSession() {
            return base.Channel.EndSession();
        }
        
        public System.Threading.Tasks.Task<Patient.CovidPatient[]> EndSessionAsync() {
            return base.Channel.EndSessionAsync();
        }
    }
}
