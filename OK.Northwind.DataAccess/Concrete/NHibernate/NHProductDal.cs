using OK.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Core.DataAccess.NHibernate;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.Concrete;
using OK.NorthWind.Entities.ComplexTypes;

namespace OK.Northwind.DataAccess.Concrete.NHibernate
{
    public class NHProductDal:NHEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;

        public NHProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                    select new ProductDetail()
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName
                    };

                return result.ToList();
            }
        }
    }
}
