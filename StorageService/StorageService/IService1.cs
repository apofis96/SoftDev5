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
        /// <summary>
        /// return Order by OrderId, return null if OrderId not found
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [OperationContract]
        Order GetDispatchedProducts(int OrderId);

        /// <summary>
        /// return true if there is desired product in desired quantity
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsAvailable(string ProductName, int quantity);

        /// <summary>
        /// Dispatches desired product in desired quantity so new order can be tacken using "GetDispatchedProducts".
        /// OrderId -1 is returned when order cannot be placed (product not found, quantity too gig) 
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [OperationContract]
        int Dispatch(string ProductName, int quantity);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Order
    {
        public Order(int orderid, int prodid, string name , int Quantity)
        {
            this.OrderID = orderid;
            this.ProductID = prodid;
            this.PoductName = name;
            this.Quantity = Quantity;
        }
        [DataMember]
        public int OrderID { get; private set; }

        [DataMember]
        public int ProductID { get; private set; }

        [DataMember]
        public string PoductName { get; private set; }

        [DataMember]
        public int Quantity { get; private set; }

        [DataMember]
        public int Price { get; set; }
    }
}
