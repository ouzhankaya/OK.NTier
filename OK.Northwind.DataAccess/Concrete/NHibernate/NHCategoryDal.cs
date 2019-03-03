using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Core.DataAccess.NHibernate;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.DataAccess.Concrete.NHibernate
{
    public class NHCategoryDal:NHEntityRepositoryBase<Category>, ICategoryDal
    {
        public NHCategoryDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {
            
        }
    }
}
