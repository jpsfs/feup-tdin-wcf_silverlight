﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApplication.Web.Server {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
    [System.SerializableAttribute()]
    public partial class LoginException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginErrorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoginError {
            get {
                return this.LoginErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginErrorField, value) != true)) {
                    this.LoginErrorField = value;
                    this.RaisePropertyChanged("LoginError");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GenericException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
    [System.SerializableAttribute()]
    public partial class GenericException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientInfo", Namespace="http://schemas.datacontract.org/2004/07/Server.Serializables")]
    [System.SerializableAttribute()]
    public partial class ClientInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApplication.Web.Server.ClientRole RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SessionIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientApplication.Web.Server.ClientRole Role {
            get {
                return this.RoleField;
            }
            set {
                if ((this.RoleField.Equals(value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionID {
            get {
                return this.SessionIDField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionIDField, value) != true)) {
                    this.SessionIDField = value;
                    this.RaisePropertyChanged("SessionID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientRole", Namespace="http://schemas.datacontract.org/2004/07/Server.Serializables")]
    public enum ClientRole : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        user = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        admin = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionType", Namespace="http://schemas.datacontract.org/2004/07/Server.Serializables")]
    public enum TransactionType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Buy = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sell = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PermissionDeniedException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
    [System.SerializableAttribute()]
    public partial class PermissionDeniedException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Transaction", Namespace="http://schemas.datacontract.org/2004/07/Server.Serializables")]
    [System.SerializableAttribute()]
    public partial class Transaction : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClientIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> OperationValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApplication.Web.Server.TransactionState StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StockTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> StockValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApplication.Web.Server.TransactionType TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> OperationValue {
            get {
                return this.OperationValueField;
            }
            set {
                if ((this.OperationValueField.Equals(value) != true)) {
                    this.OperationValueField = value;
                    this.RaisePropertyChanged("OperationValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientApplication.Web.Server.TransactionState State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StockType {
            get {
                return this.StockTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.StockTypeField, value) != true)) {
                    this.StockTypeField = value;
                    this.RaisePropertyChanged("StockType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> StockValue {
            get {
                return this.StockValueField;
            }
            set {
                if ((this.StockValueField.Equals(value) != true)) {
                    this.StockValueField = value;
                    this.RaisePropertyChanged("StockValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientApplication.Web.Server.TransactionType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionState", Namespace="http://schemas.datacontract.org/2004/07/Server.Serializables")]
    public enum TransactionState : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute(Value="To Perform")]
        ToPerform = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Performed = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server.IServiceTcp", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IServiceTcp {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/DoWork", ReplyAction="http://tempuri.org/IServiceTcp/DoWorkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.LoginException), Action="http://tempuri.org/IServiceTcp/DoWorkLoginExceptionFault", Name="LoginException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/Login", ReplyAction="http://tempuri.org/IServiceTcp/LoginResponse")]
        bool Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/Register", ReplyAction="http://tempuri.org/IServiceTcp/RegisterResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.GenericException), Action="http://tempuri.org/IServiceTcp/RegisterGenericExceptionFault", Name="GenericException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        void Register(string username, string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/GetSession", ReplyAction="http://tempuri.org/IServiceTcp/GetSessionResponse")]
        ClientApplication.Web.Server.ClientInfo GetSession(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/NewTransaction", ReplyAction="http://tempuri.org/IServiceTcp/NewTransactionResponse")]
        void NewTransaction(ClientApplication.Web.Server.TransactionType Type, double Quantity, string StockType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/NewTransactionBalcon", ReplyAction="http://tempuri.org/IServiceTcp/NewTransactionBalconResponse")]
        void NewTransactionBalcon(string ClientEmail, ClientApplication.Web.Server.TransactionType Type, double Quantity, string StockType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/PerformTransaction", ReplyAction="http://tempuri.org/IServiceTcp/PerformTransactionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.GenericException), Action="http://tempuri.org/IServiceTcp/PerformTransactionGenericExceptionFault", Name="GenericException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.PermissionDeniedException), Action="http://tempuri.org/IServiceTcp/PerformTransactionPermissionDeniedExceptionFault", Name="PermissionDeniedException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        void PerformTransaction(int id, double stockValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/ListTransaction", ReplyAction="http://tempuri.org/IServiceTcp/ListTransactionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.GenericException), Action="http://tempuri.org/IServiceTcp/ListTransactionGenericExceptionFault", Name="GenericException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientApplication.Web.Server.PermissionDeniedException), Action="http://tempuri.org/IServiceTcp/ListTransactionPermissionDeniedExceptionFault", Name="PermissionDeniedException", Namespace="http://schemas.datacontract.org/2004/07/Server.Exceptions")]
        ClientApplication.Web.Server.Transaction[] ListTransaction();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTcp/ListClientsEmail", ReplyAction="http://tempuri.org/IServiceTcp/ListClientsEmailResponse")]
        string[] ListClientsEmail();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceTcpChannel : ClientApplication.Web.Server.IServiceTcp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceTcpClient : System.ServiceModel.ClientBase<ClientApplication.Web.Server.IServiceTcp>, ClientApplication.Web.Server.IServiceTcp {
        
        public ServiceTcpClient() {
        }
        
        public ServiceTcpClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceTcpClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTcpClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTcpClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public void Register(string username, string name, string email, string password) {
            base.Channel.Register(username, name, email, password);
        }
        
        public ClientApplication.Web.Server.ClientInfo GetSession(string username) {
            return base.Channel.GetSession(username);
        }
        
        public void NewTransaction(ClientApplication.Web.Server.TransactionType Type, double Quantity, string StockType) {
            base.Channel.NewTransaction(Type, Quantity, StockType);
        }
        
        public void NewTransactionBalcon(string ClientEmail, ClientApplication.Web.Server.TransactionType Type, double Quantity, string StockType) {
            base.Channel.NewTransactionBalcon(ClientEmail, Type, Quantity, StockType);
        }
        
        public void PerformTransaction(int id, double stockValue) {
            base.Channel.PerformTransaction(id, stockValue);
        }
        
        public ClientApplication.Web.Server.Transaction[] ListTransaction() {
            return base.Channel.ListTransaction();
        }
        
        public string[] ListClientsEmail() {
            return base.Channel.ListClientsEmail();
        }
    }
}
