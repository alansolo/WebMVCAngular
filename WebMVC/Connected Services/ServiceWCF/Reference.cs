﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC.ServiceWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceWCF.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OperacionChicharronera", ReplyAction="http://tempuri.org/IService1/OperacionChicharroneraResponse")]
        int OperacionChicharronera(int value1, int value2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OperacionChicharronera", ReplyAction="http://tempuri.org/IService1/OperacionChicharroneraResponse")]
        System.Threading.Tasks.Task<int> OperacionChicharroneraAsync(int value1, int value2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        WCFPrueba.CompositeType GetDataUsingDataContract(WCFPrueba.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WCFPrueba.CompositeType> GetDataUsingDataContractAsync(WCFPrueba.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebMVC.ServiceWCF.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebMVC.ServiceWCF.IService1>, WebMVC.ServiceWCF.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int OperacionChicharronera(int value1, int value2) {
            return base.Channel.OperacionChicharronera(value1, value2);
        }
        
        public System.Threading.Tasks.Task<int> OperacionChicharroneraAsync(int value1, int value2) {
            return base.Channel.OperacionChicharroneraAsync(value1, value2);
        }
        
        public WCFPrueba.CompositeType GetDataUsingDataContract(WCFPrueba.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WCFPrueba.CompositeType> GetDataUsingDataContractAsync(WCFPrueba.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}