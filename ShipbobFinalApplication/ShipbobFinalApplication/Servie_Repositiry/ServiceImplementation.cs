using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipbobFinalApplication.Controllers;

namespace ShipbobFinalApplication.Servie_Repositiry
{
    public class ServiceImplementation : IService
    {
        public List<userBean> addMethod(user u)
        {
            ShipbobEntities entities = new ShipbobEntities();
            var maxID = entities.users.Max(p => (int?)p.userID) ?? 0;
            u.userID = maxID + 1;
            entities.users.Add(u);
            entities.SaveChanges();
            return (selectMethod());
        }

        public void createOrderMethod(order o)
        {
            ShipbobEntities entities = new ShipbobEntities();
            Random rnd = new Random();
            String trackID = "SB" + rnd.Next(1, 1000) + o.trackingID;
            o.trackingID = trackID;
            entities.orders.Add(o);
            entities.SaveChanges();
        }

        public void deleteOrderMethod(order o)
        {
            ShipbobEntities entities = new ShipbobEntities();
            entities.Entry(o).State = System.Data.EntityState.Deleted;
            entities.SaveChanges();
        }

        public List<orderBean> editOrderMethod(order o)
        {
            List<orderBean> obList = new List<orderBean>();
            ShipbobEntities entities = new ShipbobEntities();
            orderBean ordBean = new orderBean();
            ordBean.userID = entities.orders.First(a => a.trackingID == o.trackingID).userID;
            ordBean.trackingID = o.trackingID;
            ordBean.orderID = entities.orders.First(a => a.trackingID == o.trackingID).orderID;
            ordBean.street = entities.orders.First(a => a.trackingID == o.trackingID).street;
            ordBean.state = entities.orders.First(a => a.trackingID == o.trackingID).state;
            ordBean.zipCode = entities.orders.First(a => a.trackingID == o.trackingID).zipCode;
            obList.Add(ordBean);
            return (obList);
        }

        public List<userBean> selectMethod()
        {
            List<userBean> ubList = new List<userBean>();
            ShipbobEntities entities = new ShipbobEntities();
            List<int> uid = (from userBean in entities.users select userBean.userID).ToList();
            //System.Diagnostics.Debug.WriteLine("--> "+ uid);
            List<String> fn = (from userBean in entities.users select userBean.firstName).ToList();
            List<String> ln = (from userBean in entities.users select userBean.lastName).ToList();
            for (int i = 0; i < fn.Count; i++)
            {
                userBean ubean = new userBean();
                ubean.userID = uid[i];
                ubean.firstName = fn[i];
                ubean.lastName = ln[i];
                ubList.Add(ubean);
            }
            return (ubList);
        }

        public List<orderBean> selectOrderMethod()
        {
            List<orderBean> obList = new List<orderBean>();
            ShipbobEntities entities = new ShipbobEntities();
            List<int> uid = (from orderBean in entities.orders select orderBean.userID).ToList();
            List<String> tid = (from orderBean in entities.orders select orderBean.trackingID).ToList();
            List<int> oid = (from orderBean in entities.orders select orderBean.orderID).ToList();
            List<String> str = (from orderBean in entities.orders select orderBean.street).ToList();
            List<String> sta = (from orderBean in entities.orders select orderBean.state).ToList();
            List<int> zip = (from orderBean in entities.orders select orderBean.zipCode).ToList();
            //System.Diagnostics.Debug.WriteLine("--> " + uid);
            for (int i = 0; i < uid.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine("--> " + uid.Count);
                orderBean obean = new orderBean();
                obean.userID = uid[i];
                obean.trackingID = tid[i];
                obean.orderID = oid[i];
                obean.street = str[i];
                obean.state = sta[i];
                obean.zipCode = zip[i];
                obList.Add(obean);
            }
            return (obList);
        }

        public void updateOrderMethod(order o)
        {
            ShipbobEntities entities = new ShipbobEntities();
            entities.Entry(o).State = System.Data.EntityState.Modified;
            entities.SaveChanges();
        }

        public List<orderBean> viewOrderMethod(order o)
        {
            List<orderBean> obList = new List<orderBean>();
            ShipbobEntities entities = new ShipbobEntities();
            orderBean ordBean = new orderBean();
            List<int> uid = (from orderBean in entities.orders select orderBean.userID).ToList();
            List<String> tid = (from orderBean in entities.orders select orderBean.trackingID).ToList();
            List<int> oid = (from orderBean in entities.orders select orderBean.orderID).ToList();
            List<String> str = (from orderBean in entities.orders select orderBean.street).ToList();
            List<String> sta = (from orderBean in entities.orders select orderBean.state).ToList();
            List<int> zip = (from orderBean in entities.orders select orderBean.zipCode).ToList();
            for (int i = 0; i < uid.Count; i++)
            {
                if (uid[i] == o.userID)
                {
                    orderBean obean = new orderBean();
                    obean.userID = uid[i];
                    obean.trackingID = tid[i];
                    obean.orderID = oid[i];
                    obean.street = str[i];
                    obean.state = sta[i];
                    obean.zipCode = zip[i];
                    obList.Add(obean);
                }
            }
            return (obList);
        }
    }
}