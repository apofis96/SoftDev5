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
        Product ProductToDispatch;
        List<ProductInfo> AllProducts;
        public Storage()
        {
            AllProducts = new List<ProductInfo>()
            {new ProductInfo(){ Id = 1, Name="Product1", Quantity= 39 },
            new ProductInfo(){ Id = 1, Name="Product2", Quantity= 88 },
            new ProductInfo(){ Id = 1, Name="Product3", Quantity= 140 },
            new ProductInfo(){ Id = 1, Name="Product4", Quantity= 15 },
            new ProductInfo(){ Id = 1, Name="Product5", Quantity= 74 },
            new ProductInfo(){ Id = 1, Name="Product6", Quantity= 22 } };
            ProductToDispatch = null;
        }
        //Check if desired amount of products ARE
        public bool IsAvailable(int ProductID, int quantity)
        {
           ProductInfo p =  AllProducts.Where(t => t.Id == ProductID).FirstOrDefault();
            if (p != null && p.Quantity >= quantity)
                return true;
            return false;
        }
        // return true if Products was successfully Dispatched, otherwise false.
        // Product dispatched means that it can be taken using "GetDispatchedProduct" method
        public bool Dispatch(int ProductID, int quantity)
        {
            if (IsAvailable(ProductID, quantity))
            {
                ProductInfo pinf = AllProducts.Where(t => t.Id == ProductID).FirstOrDefault();
                Product p = new Product(pinf.Id, pinf.Name);
                p.Price = 0;
                pinf.Quantity--;
                ProductToDispatch = p;
                return true;
            }
            return false;
        }
        //return Product, only with Product name, quantity and id
        public Product GetDispatchedProducts()
        {
            Product c = ProductToDispatch;
            ProductToDispatch = null;
            return c;
        }
    }
    class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
