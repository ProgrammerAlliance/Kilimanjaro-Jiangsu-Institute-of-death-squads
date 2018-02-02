using NLC.Order.IBLL;
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IDAL;
using NLC.Order.DALFactory;

namespace NLC.Order.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private IOrderDAL userDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();
        public JsonResult CancelOrder(int UserId)
        {
            throw new NotImplementedException();
        }

        public JsonResult CountOrderNumber()
        {
            throw new NotImplementedException();
        }

        public JsonResult GetOrderPeople(OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public JsonResult OrderFood()
        {
            throw new NotImplementedException();
        }

        public JsonResult ProudceSweep()
        {
            throw new NotImplementedException();
        }
    }
}
