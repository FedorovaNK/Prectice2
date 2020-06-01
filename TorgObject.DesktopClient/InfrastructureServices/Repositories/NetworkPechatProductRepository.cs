using TorgObject.ApplicationServices.Ports.Cache;
using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TorgObject.InfrastructureServices.Repositories
{
    public class NetworkPechatProductRepository : NetworkRepositoryBase, IReadOnlyPechatProductRepository
    {
        private readonly IDomainObjectsCache<PechatProduct> _pechatproductCache;

        public NetworkPechatProductRepository(string host, ushort port, bool useTls, IDomainObjectsCache<PechatProduct> pechatproductCache)
            : base(host, port, useTls)
            => _pechatproductCache = pechatproductCache;

        public async Task<PechatProduct> GetPechatProduct(long id)
            => CacheAndReturn(await ExecuteHttpRequest<PechatProduct>($"pechatproducts/{id}"));

        public async Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<PechatProduct>>($"pechatproducts"), allObjects: true);

        public async Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<PechatProduct>>($"pechatproducts"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<PechatProduct> CacheAndReturn(IEnumerable<PechatProduct> pechatproducts, bool allObjects = false)
        {
            if (allObjects)
            {
                _pechatproductCache.ClearCache();
            }
            _pechatproductCache.UpdateObjects(pechatproducts, DateTime.Now.AddDays(1), allObjects);
            return pechatproducts;
        }

        private PechatProduct CacheAndReturn(PechatProduct pechatproduct)
        {
            _pechatproductCache.UpdateObject(pechatproduct, DateTime.Now.AddDays(1));
            return pechatproduct;
        }
    }
}
