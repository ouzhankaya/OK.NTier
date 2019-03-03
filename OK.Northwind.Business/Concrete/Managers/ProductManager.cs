using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Northwind.Business.Abstract;
using OK.Northwind.Business.ValidationRules.FluentValidation;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.Concrete;
using OK.Core.Aspects.PostSharp;
using OK.Core.Aspects.PostSharp.TransactionAspect;
using OK.Core.CrossCuttingConcerns.Caching.Microsoft;
using OK.Core.Aspects.PostSharp.CacheAspects;
using OK.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using OK.Core.Aspects.Postsharp.LogAspects;
using OK.Core.Aspects.Postsharp.ExceptionAspects;
using System.Threading;
using AutoMapper;
using OK.Core.Aspects.PostSharp.AuthorizationAspects;
using OK.Core.Utilities.Mapping;

namespace OK.Northwind.Business.Concrete.Managers
{
    //[LogAspect(typeof(DatabaseLogger))]
    //[LogAspect(typeof(JsonFileLogger))] class bazlı loglama
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager),60)]
        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetList());

            return products;
        }

       
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
 