﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackupDaemon.ServerReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="tbDaemon", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class tbDaemon : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DaemonNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IpAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PcNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RefreshRateField;
        
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
        public string DaemonName {
            get {
                return this.DaemonNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DaemonNameField, value) != true)) {
                    this.DaemonNameField = value;
                    this.RaisePropertyChanged("DaemonName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IpAddress {
            get {
                return this.IpAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.IpAddressField, value) != true)) {
                    this.IpAddressField = value;
                    this.RaisePropertyChanged("IpAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastActive {
            get {
                return this.LastActiveField;
            }
            set {
                if ((this.LastActiveField.Equals(value) != true)) {
                    this.LastActiveField = value;
                    this.RaisePropertyChanged("LastActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PcName {
            get {
                return this.PcNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PcNameField, value) != true)) {
                    this.PcNameField = value;
                    this.RaisePropertyChanged("PcName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RefreshRate {
            get {
                return this.RefreshRateField;
            }
            set {
                if ((this.RefreshRateField.Equals(value) != true)) {
                    this.RefreshRateField = value;
                    this.RaisePropertyChanged("RefreshRate");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="tbDestination", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class tbDestination : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BackupDaemon.ServerReference.tbTask[] LTaskField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BackupDaemon.ServerReference.tbTask[] LTask {
            get {
                return this.LTaskField;
            }
            set {
                if ((object.ReferenceEquals(this.LTaskField, value) != true)) {
                    this.LTaskField = value;
                    this.RaisePropertyChanged("LTask");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="tbTask", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class tbTask : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BackupDaemon.ServerReference.tbDaemon DaemonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DaemonIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KronExpressionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BackupDaemon.ServerReference.tbDestination[] LDestinationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastTaskCommitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TaskFinishedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaskNameField;
        
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
        public BackupDaemon.ServerReference.tbDaemon Daemon {
            get {
                return this.DaemonField;
            }
            set {
                if ((object.ReferenceEquals(this.DaemonField, value) != true)) {
                    this.DaemonField = value;
                    this.RaisePropertyChanged("Daemon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DaemonId {
            get {
                return this.DaemonIdField;
            }
            set {
                if ((this.DaemonIdField.Equals(value) != true)) {
                    this.DaemonIdField = value;
                    this.RaisePropertyChanged("DaemonId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string KronExpression {
            get {
                return this.KronExpressionField;
            }
            set {
                if ((object.ReferenceEquals(this.KronExpressionField, value) != true)) {
                    this.KronExpressionField = value;
                    this.RaisePropertyChanged("KronExpression");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BackupDaemon.ServerReference.tbDestination[] LDestination {
            get {
                return this.LDestinationField;
            }
            set {
                if ((object.ReferenceEquals(this.LDestinationField, value) != true)) {
                    this.LDestinationField = value;
                    this.RaisePropertyChanged("LDestination");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastTaskCommit {
            get {
                return this.LastTaskCommitField;
            }
            set {
                if ((this.LastTaskCommitField.Equals(value) != true)) {
                    this.LastTaskCommitField = value;
                    this.RaisePropertyChanged("LastTaskCommit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TaskFinished {
            get {
                return this.TaskFinishedField;
            }
            set {
                if ((this.TaskFinishedField.Equals(value) != true)) {
                    this.TaskFinishedField = value;
                    this.RaisePropertyChanged("TaskFinished");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TaskName {
            get {
                return this.TaskNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TaskNameField, value) != true)) {
                    this.TaskNameField = value;
                    this.RaisePropertyChanged("TaskName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="tbLog", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class tbLog : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BackupDaemon.ServerReference.tbDaemon DaemonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DaemonIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public BackupDaemon.ServerReference.tbDaemon Daemon {
            get {
                return this.DaemonField;
            }
            set {
                if ((object.ReferenceEquals(this.DaemonField, value) != true)) {
                    this.DaemonField = value;
                    this.RaisePropertyChanged("Daemon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DaemonId {
            get {
                return this.DaemonIdField;
            }
            set {
                if ((this.DaemonIdField.Equals(value) != true)) {
                    this.DaemonIdField = value;
                    this.RaisePropertyChanged("DaemonId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadString", ReplyAction="http://tempuri.org/IService1/UploadStringResponse")]
        void UploadString(string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadString", ReplyAction="http://tempuri.org/IService1/UploadStringResponse")]
        System.Threading.Tasks.Task UploadStringAsync(string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadDaemon", ReplyAction="http://tempuri.org/IService1/UploadDaemonResponse")]
        void UploadDaemon(BackupDaemon.ServerReference.tbDaemon o);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadDaemon", ReplyAction="http://tempuri.org/IService1/UploadDaemonResponse")]
        System.Threading.Tasks.Task UploadDaemonAsync(BackupDaemon.ServerReference.tbDaemon o);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadDestination", ReplyAction="http://tempuri.org/IService1/UploadDestinationResponse")]
        void UploadDestination(BackupDaemon.ServerReference.tbDestination d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadDestination", ReplyAction="http://tempuri.org/IService1/UploadDestinationResponse")]
        System.Threading.Tasks.Task UploadDestinationAsync(BackupDaemon.ServerReference.tbDestination d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadLog", ReplyAction="http://tempuri.org/IService1/UploadLogResponse")]
        void UploadLog(BackupDaemon.ServerReference.tbLog l);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadLog", ReplyAction="http://tempuri.org/IService1/UploadLogResponse")]
        System.Threading.Tasks.Task UploadLogAsync(BackupDaemon.ServerReference.tbLog l);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadTask", ReplyAction="http://tempuri.org/IService1/UploadTaskResponse")]
        void UploadTask(BackupDaemon.ServerReference.tbTask t);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadTask", ReplyAction="http://tempuri.org/IService1/UploadTaskResponse")]
        System.Threading.Tasks.Task UploadTaskAsync(BackupDaemon.ServerReference.tbTask t);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateDaemonLastActive", ReplyAction="http://tempuri.org/IService1/UpdateDaemonLastActiveResponse")]
        void UpdateDaemonLastActive(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateDaemonLastActive", ReplyAction="http://tempuri.org/IService1/UpdateDaemonLastActiveResponse")]
        System.Threading.Tasks.Task UpdateDaemonLastActiveAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CheckDeamonReference", ReplyAction="http://tempuri.org/IService1/CheckDeamonReferenceResponse")]
        bool CheckDeamonReference(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CheckDeamonReference", ReplyAction="http://tempuri.org/IService1/CheckDeamonReferenceResponse")]
        System.Threading.Tasks.Task<bool> CheckDeamonReferenceAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateDeamonReference", ReplyAction="http://tempuri.org/IService1/UpdateDeamonReferenceResponse")]
        void UpdateDeamonReference(int id, BackupDaemon.ServerReference.tbDaemon d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateDeamonReference", ReplyAction="http://tempuri.org/IService1/UpdateDeamonReferenceResponse")]
        System.Threading.Tasks.Task UpdateDeamonReferenceAsync(int id, BackupDaemon.ServerReference.tbDaemon d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExistDeamonTask", ReplyAction="http://tempuri.org/IService1/ExistDeamonTaskResponse")]
        bool ExistDeamonTask(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExistDeamonTask", ReplyAction="http://tempuri.org/IService1/ExistDeamonTaskResponse")]
        System.Threading.Tasks.Task<bool> ExistDeamonTaskAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDeamonTask", ReplyAction="http://tempuri.org/IService1/GetDeamonTaskResponse")]
        BackupDaemon.ServerReference.tbTask[] GetDeamonTask(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDeamonTask", ReplyAction="http://tempuri.org/IService1/GetDeamonTaskResponse")]
        System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbTask[]> GetDeamonTaskAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewLogMessage", ReplyAction="http://tempuri.org/IService1/NewLogMessageResponse")]
        void NewLogMessage(int DaemonId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewLogMessage", ReplyAction="http://tempuri.org/IService1/NewLogMessageResponse")]
        System.Threading.Tasks.Task NewLogMessageAsync(int DaemonId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllDaemons", ReplyAction="http://tempuri.org/IService1/GetAllDaemonsResponse")]
        BackupDaemon.ServerReference.tbDaemon[] GetAllDaemons();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllDaemons", ReplyAction="http://tempuri.org/IService1/GetAllDaemonsResponse")]
        System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbDaemon[]> GetAllDaemonsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDaemon", ReplyAction="http://tempuri.org/IService1/GetDaemonResponse")]
        BackupDaemon.ServerReference.tbDaemon GetDaemon(BackupDaemon.ServerReference.tbDaemon o);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDaemon", ReplyAction="http://tempuri.org/IService1/GetDaemonResponse")]
        System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbDaemon> GetDaemonAsync(BackupDaemon.ServerReference.tbDaemon o);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        BackupDaemon.ServerReference.CompositeType GetDataUsingDataContract(BackupDaemon.ServerReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<BackupDaemon.ServerReference.CompositeType> GetDataUsingDataContractAsync(BackupDaemon.ServerReference.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : BackupDaemon.ServerReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<BackupDaemon.ServerReference.IService1>, BackupDaemon.ServerReference.IService1 {
        
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
        
        public void UploadString(string s) {
            base.Channel.UploadString(s);
        }
        
        public System.Threading.Tasks.Task UploadStringAsync(string s) {
            return base.Channel.UploadStringAsync(s);
        }
        
        public void UploadDaemon(BackupDaemon.ServerReference.tbDaemon o) {
            base.Channel.UploadDaemon(o);
        }
        
        public System.Threading.Tasks.Task UploadDaemonAsync(BackupDaemon.ServerReference.tbDaemon o) {
            return base.Channel.UploadDaemonAsync(o);
        }
        
        public void UploadDestination(BackupDaemon.ServerReference.tbDestination d) {
            base.Channel.UploadDestination(d);
        }
        
        public System.Threading.Tasks.Task UploadDestinationAsync(BackupDaemon.ServerReference.tbDestination d) {
            return base.Channel.UploadDestinationAsync(d);
        }
        
        public void UploadLog(BackupDaemon.ServerReference.tbLog l) {
            base.Channel.UploadLog(l);
        }
        
        public System.Threading.Tasks.Task UploadLogAsync(BackupDaemon.ServerReference.tbLog l) {
            return base.Channel.UploadLogAsync(l);
        }
        
        public void UploadTask(BackupDaemon.ServerReference.tbTask t) {
            base.Channel.UploadTask(t);
        }
        
        public System.Threading.Tasks.Task UploadTaskAsync(BackupDaemon.ServerReference.tbTask t) {
            return base.Channel.UploadTaskAsync(t);
        }
        
        public void UpdateDaemonLastActive(int id) {
            base.Channel.UpdateDaemonLastActive(id);
        }
        
        public System.Threading.Tasks.Task UpdateDaemonLastActiveAsync(int id) {
            return base.Channel.UpdateDaemonLastActiveAsync(id);
        }
        
        public bool CheckDeamonReference(int id) {
            return base.Channel.CheckDeamonReference(id);
        }
        
        public System.Threading.Tasks.Task<bool> CheckDeamonReferenceAsync(int id) {
            return base.Channel.CheckDeamonReferenceAsync(id);
        }
        
        public void UpdateDeamonReference(int id, BackupDaemon.ServerReference.tbDaemon d) {
            base.Channel.UpdateDeamonReference(id, d);
        }
        
        public System.Threading.Tasks.Task UpdateDeamonReferenceAsync(int id, BackupDaemon.ServerReference.tbDaemon d) {
            return base.Channel.UpdateDeamonReferenceAsync(id, d);
        }
        
        public bool ExistDeamonTask(int id) {
            return base.Channel.ExistDeamonTask(id);
        }
        
        public System.Threading.Tasks.Task<bool> ExistDeamonTaskAsync(int id) {
            return base.Channel.ExistDeamonTaskAsync(id);
        }
        
        public BackupDaemon.ServerReference.tbTask[] GetDeamonTask(int id) {
            return base.Channel.GetDeamonTask(id);
        }
        
        public System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbTask[]> GetDeamonTaskAsync(int id) {
            return base.Channel.GetDeamonTaskAsync(id);
        }
        
        public void NewLogMessage(int DaemonId, string message) {
            base.Channel.NewLogMessage(DaemonId, message);
        }
        
        public System.Threading.Tasks.Task NewLogMessageAsync(int DaemonId, string message) {
            return base.Channel.NewLogMessageAsync(DaemonId, message);
        }
        
        public BackupDaemon.ServerReference.tbDaemon[] GetAllDaemons() {
            return base.Channel.GetAllDaemons();
        }
        
        public System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbDaemon[]> GetAllDaemonsAsync() {
            return base.Channel.GetAllDaemonsAsync();
        }
        
        public BackupDaemon.ServerReference.tbDaemon GetDaemon(BackupDaemon.ServerReference.tbDaemon o) {
            return base.Channel.GetDaemon(o);
        }
        
        public System.Threading.Tasks.Task<BackupDaemon.ServerReference.tbDaemon> GetDaemonAsync(BackupDaemon.ServerReference.tbDaemon o) {
            return base.Channel.GetDaemonAsync(o);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public BackupDaemon.ServerReference.CompositeType GetDataUsingDataContract(BackupDaemon.ServerReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<BackupDaemon.ServerReference.CompositeType> GetDataUsingDataContractAsync(BackupDaemon.ServerReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
