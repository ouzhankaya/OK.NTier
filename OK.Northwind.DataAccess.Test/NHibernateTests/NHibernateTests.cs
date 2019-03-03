using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OK.Northwind.DataAccess.Concrete.EntityFramework;
using OK.Northwind.DataAccess.Concrete.NHibernate;
using OK.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace OK.Northwind.DataAccess.Test.EntityFrameworkTest
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NHProductDal productDal = new NHProductDal(new SqlServerHelper());

            var result = productDal.GetList();

            Assert.AreEqual(78,result.Count);
        }

        [TestMethod]

        public void Get_all_with_parameters_returns_filtered_products()
        {
            NHProductDal productDal = new NHProductDal(new SqlServerHelper());

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4,result.Count);
        }
    }
}
