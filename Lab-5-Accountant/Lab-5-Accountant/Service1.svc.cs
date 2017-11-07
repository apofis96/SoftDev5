using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab_5_Accountant
{
 
    public class AccountantService : IAccountant
    {
        //ціна за одиницю товару
        Dictionary<int, int> priceList = new Dictionary<int, int>
        {
            [1] = 20,
            [2] = 10,
            [3] = 45,
            [4] = 33,
            [5] = 16,
            [6] = 17
        };



        //отримати загальну ціну на товар
        public int GetPrice(int productID, int quantity)
        {
            if (priceList.ContainsKey(productID))
                return priceList[productID] * quantity;
            return 0;//если переданого id в прайслисте нет, можно возвращать, например, 0
        }


        //звіт про результат доставки
        public void LogResult(string productName, int quantity, bool success)
        {
            string fileName = "Report.log";
            string directory = @"C:\Logs";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(directory, fileName), FileMode.Append)))
            {
                if (success)
                {
                    writer.WriteLine(DateTime.Now + "  Товар доставлено: {0}, {1} од.", productName, quantity);
                }
                else
                {
                    writer.WriteLine(DateTime.Now + "  Доставка НЕ відбулась: {0}, {1} од.", productName, quantity);
                }
            }
        }

    }
}
