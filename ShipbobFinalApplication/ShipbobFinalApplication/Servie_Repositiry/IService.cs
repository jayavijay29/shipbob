using ShipbobFinalApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipbobFinalApplication.Servie_Repositiry
{
    interface IService
    {
        List<userBean> addMethod(user u);
        List<userBean> selectMethod();
        void createOrderMethod(order o);
        List<orderBean> selectOrderMethod();
        List<orderBean> editOrderMethod(order o);
        void updateOrderMethod(order o);
        void deleteOrderMethod(order o);
        List<orderBean> viewOrderMethod(order o);
    }
}
