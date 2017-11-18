using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipbobFinalApplication.Controllers
{
    public class orderBean
    {
        public int userID { get; set; }
        public string trackingID { get; set; }
        public int orderID { get; set; }
        public string street { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
    }
}