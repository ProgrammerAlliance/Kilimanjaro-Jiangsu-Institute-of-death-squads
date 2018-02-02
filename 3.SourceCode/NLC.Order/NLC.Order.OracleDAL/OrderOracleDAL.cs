using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.Order.Model;

namespace NLC.Order.OracleDAL
{
    public class OrderOracleDAL : IOrderDAL
    {
        public bool AddOrder(OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public List<OrderInfo> Cleaner()
        {
            throw new NotImplementedException();
        }

        public string GetName(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool ModifyCleanState(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool SubOrder(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
