using ShipbobFinalApplication.Servie_Repositiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShipbobFinalApplication.Controllers
{
    public class AjaxAPIController : ApiController
    {
        IService serviceImplementation = new ServiceImplementation();

        //Viewing all the Users.
        [Route("api/AjaxAPI/SelectMethod")]
        [HttpPost]
        public List<userBean> selectMethod()
        {
            return (serviceImplementation.selectMethod());
        }

        //Creating Users.
        [Route("api/AjaxAPI/AddMethod")]
        [HttpPost]
        public List<userBean> addMethod(user us)
        {
            return (serviceImplementation.addMethod(us));
        }

        //Creating Orders.
        [Route("api/AjaxAPI/CreateOrderMethod")]
        [HttpPost]
        public void createOrderMethod(order o)
        {
            serviceImplementation.createOrderMethod(o);
        }

        //Viewing Orders
        [Route("api/AjaxAPI/SelectOrderMethod")]
        [HttpPost]
        public List<orderBean> selectOrderMethod()
        {
            return (serviceImplementation.selectOrderMethod());
        }

        //Editing Order
        [Route("api/AjaxAPI/EditOrderMethod")]
        [HttpPost]
        public List<orderBean> editOrderMethod(order o)
        {
            return (serviceImplementation.editOrderMethod(o));
        }

        //Updating Order
        [Route("api/AjaxAPI/UpdateOrderMethod")]
        [HttpPost]
        public void updateOrderMethod(order o)
        {
            serviceImplementation.updateOrderMethod(o);
        }

        //Deleteing Order
        [Route("api/AjaxAPI/DeleteOrderMethod")]
        [HttpPost]
        public void deleteOrderMethod(order o)
        {
            serviceImplementation.deleteOrderMethod(o);
        }

        //View Order per User
        [Route("api/AjaxAPI/ViewOrderUserMethod")]
        [HttpPost]
        public List<orderBean> viewOrderMethod(order o)
        {
            return (serviceImplementation.viewOrderMethod(o));
        }
    }
}
