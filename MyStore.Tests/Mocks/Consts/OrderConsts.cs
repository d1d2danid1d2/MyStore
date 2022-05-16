using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Mock.Consts
{
    public static class OrderConsts
    {
        public const int OrderId = 1;
        public const int CustId = 1;
        public const int EmpId = 1;
        public const int ShipperId = 1;
        public static DateTime Orderdate = new DateTime(2008, 5, 1);
        public static DateTime Requireddate = new DateTime(2008, 6, 1);
        public static DateTime? Shippeddate = new DateTime(2008, 7, 1);
        public const decimal Freight = 12.5M;
        public const string Shipname = "Test Ship";
        public const string Shipaddress = "Test Adress";
        public const string Shipcity = "Test City";
        public const string Shipregion = "Test Region";
        public const string Shippostalcode = "Test Postal Code";
        public const string Shipcountry = "Test Country";

    }
}
