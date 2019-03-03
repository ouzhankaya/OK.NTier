using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Core.DataAccess.EntityFramework;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EFEntityRepositoryBase<Category,NorthWindContext>, ICategoryDal
    {
    }
}
