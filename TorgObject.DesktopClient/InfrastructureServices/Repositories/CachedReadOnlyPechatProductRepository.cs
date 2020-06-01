using TorgObject.ApplicationServices.Ports.Cache;
using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using TorgObject.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObject.InfrastructureServices.Repositories
{
    public class CachedReadOnlyPechatProductRepository : ReadOnlyPechatProductRepositoryDecorator
    {
        private readonly IDomainObjectsCache<PechatProduct> _pechatproductsCache;

        public CachedReadOnlyPechatProductRepository(IReadOnlyPechatProductRepository pechatproductRepository, 
                                                     IDomainObjectsCache<PechatProduct> pechatproductsCache)
            : base(pechatproductRepository)
            => _pechatproductsCache = pechatproductsCache;

        public async override Task<PechatProduct> GetPechatProduct(long id)
            => _pechatproductsCache.GetObject(id) ?? await base.GetPechatProduct(id);

        public async override Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
            => _pechatproductsCache.GetObjects() ?? await base.GetAllPechatProducts();

        public async override Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria)
            => _pechatproductsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryPechatProducts(criteria);

    }
}
