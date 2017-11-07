﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager.StorageServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/StorageService")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PoductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
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
        public int OrderID {
            get {
                return this.OrderIDField;
            }
            set {
                if ((this.OrderIDField.Equals(value) != true)) {
                    this.OrderIDField = value;
                    this.RaisePropertyChanged("OrderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PoductName {
            get {
                return this.PoductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PoductNameField, value) != true)) {
                    this.PoductNameField = value;
                    this.RaisePropertyChanged("PoductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StorageServiceReference.IStorage")]
    public interface IStorage {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/GetDispatchedProducts", ReplyAction="http://tempuri.org/IStorage/GetDispatchedProductsResponse")]
        Manager.StorageServiceReference.Order GetDispatchedProducts(int OrderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/GetDispatchedProducts", ReplyAction="http://tempuri.org/IStorage/GetDispatchedProductsResponse")]
        System.Threading.Tasks.Task<Manager.StorageServiceReference.Order> GetDispatchedProductsAsync(int OrderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/IsAvailable", ReplyAction="http://tempuri.org/IStorage/IsAvailableResponse")]
        bool IsAvailable(string ProductName, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/IsAvailable", ReplyAction="http://tempuri.org/IStorage/IsAvailableResponse")]
        System.Threading.Tasks.Task<bool> IsAvailableAsync(string ProductName, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/Dispatch", ReplyAction="http://tempuri.org/IStorage/DispatchResponse")]
        int Dispatch(string ProductName, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStorage/Dispatch", ReplyAction="http://tempuri.org/IStorage/DispatchResponse")]
        System.Threading.Tasks.Task<int> DispatchAsync(string ProductName, int quantity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStorageChannel : Manager.StorageServiceReference.IStorage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StorageClient : System.ServiceModel.ClientBase<Manager.StorageServiceReference.IStorage>, Manager.StorageServiceReference.IStorage {
        
        public StorageClient() {
        }
        
        public StorageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StorageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Manager.StorageServiceReference.Order GetDispatchedProducts(int OrderId) {
            return base.Channel.GetDispatchedProducts(OrderId);
        }
        
        public System.Threading.Tasks.Task<Manager.StorageServiceReference.Order> GetDispatchedProductsAsync(int OrderId) {
            return base.Channel.GetDispatchedProductsAsync(OrderId);
        }
        
        public bool IsAvailable(string ProductName, int quantity) {
            return base.Channel.IsAvailable(ProductName, quantity);
        }
        
        public System.Threading.Tasks.Task<bool> IsAvailableAsync(string ProductName, int quantity) {
            return base.Channel.IsAvailableAsync(ProductName, quantity);
        }
        
        public int Dispatch(string ProductName, int quantity) {
            return base.Channel.Dispatch(ProductName, quantity);
        }
        
        public System.Threading.Tasks.Task<int> DispatchAsync(string ProductName, int quantity) {
            return base.Channel.DispatchAsync(ProductName, quantity);
        }
    }
}
