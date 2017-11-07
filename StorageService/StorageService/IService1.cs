using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StorageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStorage
    {
        // TODO: Add your service operations here
        [OperationContract]
        Product GetDispatchedProducts();

        [OperationContract]
        bool IsAvailable(int ProductID, int quantity);

        [OperationContract]
        bool Dispatch(int ProductID, int quantity);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Product
    {
        public Product(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        [DataMember]
        public int ID { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Price { get; set; }
    }
}
