

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoorOrder.Exceptions;
using GreatOutdoorsOrder.Entities;
using GreatOutdoors.Contracts.DALContracts;
using GreatOutdoorsOrder.Helpers;

namespace GreatOutdoorsOrder.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting order from Orders collection.
    /// </summary>
    public class OrderDAL : OrdersDALBase, IDisposable
    {
        /// <summary>
        /// Adds new order to Orders collection.
        /// </summary>
        /// <param name="newOrder">Contains the Order details to be added.</param>
        /// <returns>Determinates whether the new Order is added.</returns>

       

        

        public override bool AddOrderDAL(Order newOrder)
        {
            bool orderAdded = false;
            try
            {
                orderList.Add(newOrder);
                orderAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return orderAdded;

        }

        /// <summary>
        /// Gets all orders from the collection.
        /// </summary>
        /// <returns>Returns list of all orders.</returns>
        public override List<Order> GetAllOrdersDAL()
        {
            return orderList;
        }

        /// <summary>
        /// Gets order based on OrderID.
        /// </summary>
        /// <param name="searchOrderID">Represents OrderID to search.</param>
        /// <returns>Returns Order object.</returns>
        public override Order SearchOrderDAL(int searchOrderID)
        {
            Order searchOrder = null;
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.OrderID == searchOrderID)
                    {
                        searchOrder = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// Gets the orders filtered by retailer ID
        /// </summary>
        /// <param name="RetailerID"></param>
        /// <returns>Returns list of orders.</returns>
        public override List<Order> GetOrderByRetailerIDDAL(int RetailerID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.RetailerID == RetailerID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// Searches for the orders placed in aparticular category.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns>The list of orders.</returns>
        public override List<Order> GetOrderByCategoryIDDAL(int categoryID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.CategoryID == categoryID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// Searches for the orders placed by a particular salesman by using the salesman ID.
        /// </summary>
        /// <param name="salesmanID"></param>
        /// <returns>the list of orders.</returns>
        public override List<Order> GetOrderBySalesmanIDDAL(int salesmanID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.SalesmanID == salesmanID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChannelOfSale"></param>
        /// <returns></returns>
        public override List<Order> GetOrderByOfflineDAL(string ChannelOfSale)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Offline")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<Order> GetOrderForOfflineSaleDAL()
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Offline" && item.Status == "In Cart")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChannelOfSale"></param>
        /// <returns></returns>
        public override List<Order> GetOrderByOnlineDAL(string ChannelOfSale)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Online")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        public override List<Order> GetOrderByStatusDAL(string CurrentStatus)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.Status == CurrentStatus)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateOrder"></param>
        /// <returns></returns>
        public override bool UpdateOrderDAL(Order updateOrder)
        {
            bool OrderUpdated = false;
            try
            {
                for (int i = 0; i < orderList.Count; i++)
                {
                    if (orderList[i].OrderID == updateOrder.OrderID)
                    {
                        updateOrder.Status = orderList[i].Status;

                        OrderUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return OrderUpdated;

        }

        public void Dispose()
        {
            //No unmanaged resources currently
        }


    }
}
