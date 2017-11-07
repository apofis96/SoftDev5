using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StorageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(
    ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class Storage : IStorage
    {
        List<ProductInfo> AllProducts;
        List<Order> Orders;
        //counts orders
        int counter;
        public Storage()
        {
            Orders = new List<Order>();
            AllProducts = new List<ProductInfo>()
            {new ProductInfo(){ Name="Product1", Quantity= 39 },
            new ProductInfo(){  Name="Product2", Quantity= 88 },
            new ProductInfo(){  Name="Product3", Quantity= 140 },
            new ProductInfo(){  Name="Product4", Quantity= 15 },
            new ProductInfo(){  Name="Product5", Quantity= 74 },
            new ProductInfo(){  Name="Product6", Quantity= 22 } };
        }
        //Check if desired amount of products ARE
        public bool IsAvailable(string ProductName, int quantity)
        {
           ProductInfo p =  AllProducts.Where(t => t.Name == ProductName).FirstOrDefault();
            if (p != null && p.Quantity >= quantity)
                return true;
            return false;
        }
        // return true if Products was successfully Dispatched, otherwise false.
        // Product dispatched means that it can be taken using "GetDispatchedProduct" method
        public int Dispatch(string ProductName, int quantity)
        {
            if (IsAvailable(ProductName, quantity))
            {
                ProductInfo pinf = AllProducts.Where(t => t.Name == ProductName).FirstOrDefault();
                Order o = new Order(counter++, pinf.Name, quantity);
                o.Price = 0;
                pinf.Quantity-= quantity;
                Orders.Add(o);
                return o.ID;
            }
            return -1;
        }
        //return Order, only with Product name, quantity and id; return null if product not found
        public Order GetDispatchedProducts(int OrderId)
        {
            Order o = Orders.Find(or => or.ID == OrderId);
            if (o != null)
                Orders.Remove(o);
            return o;
        }
    }
    class ProductInfo
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
