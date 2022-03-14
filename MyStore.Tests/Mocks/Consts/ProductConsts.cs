using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class ProductConsts
    {
        public static int CategoryId = 2;
        public static int TestProduct = 3;
        public static int TestSupplierId = 4;
        public static decimal TestUnitPrice = 152.51M;  
        public const string ProductName = "Test Product name 1";
        public enum Category
        {
            Condiments = 2,
            Confections =3,
            DairyProducts,
            Grains,
            Meat
        }

    }
}
