using System;
using System.Collections.Generic;
using System.IO;
using GreatOutdoorsOrder.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GreatOutdoors.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for OrdersDALBase class
    /// </summary>
    public abstract class OrdersDALBase
    {
        //Collection of Orders
        protected static List<Order> orderList = new List<Order>();
        private static string fileName = "order.json";

        //Methods for CRUD Operations
        public abstract bool AddOrderDAL(Order newOrder);

        public abstract List<Order> GetAllOrdersDAL();

        public abstract Order SearchOrderDAL(int searchOrderID);

        public abstract List<Order> GetOrderByRetailerIDDAL(int RetailerID);


        public abstract List<Order> GetOrderByCategoryIDDAL(int categoryID);

        public abstract List<Order> GetOrderBySalesmanIDDAL(int salesmanID);

        public abstract List<Order> GetOrderByOfflineDAL(string ChannelOfSale);

        public abstract List<Order> GetOrderForOfflineSaleDAL();

        public abstract List<Order> GetOrderByOnlineDAL(string ChannelOfSale);

        public abstract List<Order> GetOrderByStatusDAL(string CurrentStatus);

        public abstract bool UpdateOrderDAL(Order updateOrder);



        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(orderList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<Order>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    orderList = systemUserListFromFile;
                }
            }
        }


        /// <summary>
        /// Static Constructor.
        /// </summary>
        static OrdersDALBase()
        {
            Deserialize();
        }
    }
}
