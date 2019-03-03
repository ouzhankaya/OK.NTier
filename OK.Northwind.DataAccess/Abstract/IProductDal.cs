using OK.Core.DataAccess;
using OK.NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.NorthWind.Entities.ComplexTypes;

namespace OK.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //ürüne özgü metodlar kullanabileceğimiz için direkt IEntityRepository kullanmadık

        List<ProductDetail> GetProductDetails();
    }
}
