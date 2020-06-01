using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObject.DomainObjects.Repositories
{
    public abstract class ReadOnlyPechatProductRepositoryDecorator : IReadOnlyPechatProductRepository
    {
        private readonly IReadOnlyPechatProductRepository _pechatproductRepository;

        public ReadOnlyPechatProductRepositoryDecorator(IReadOnlyPechatProductRepository pechatproductRepository)
        {
            _pechatproductRepository = pechatproductRepository;
        }

        public virtual async Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
        {
            return await _pechatproductRepository?.GetAllPechatProducts();
        }

        public virtual async Task<PechatProduct> GetPechatProduct(long id)
        {
            return await _pechatproductRepository?.GetPechatProduct(id);
        }

        public virtual async Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria)
        {
            return await _pechatproductRepository?.QueryPechatProducts(criteria);
        }
    }
}
