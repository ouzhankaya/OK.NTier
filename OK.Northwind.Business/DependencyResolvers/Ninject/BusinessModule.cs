using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using OK.Core.DataAccess;
using OK.Core.DataAccess.EntityFramework;
using OK.Core.DataAccess.NHibernate;
using OK.Northwind.Business.Abstract;
using OK.Northwind.Business.Concrete.Managers;
using OK.Northwind.DataAccess.Abstract;
using OK.Northwind.DataAccess.Concrete.EntityFramework;
using OK.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace OK.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EFQueryableRepository<>));
            Bind<DbContext>().To<NorthWindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
