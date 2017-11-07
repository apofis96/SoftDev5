using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Manager
{
    [DataContract]
    public class Product
    {
        private int price = 0;

        public Product(string name, int id)
        {
            Name = name;
            ID = id;
        }

        [DataMember]
        public int ID { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Price
        {
            get
            { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
            }
        }
    }
}