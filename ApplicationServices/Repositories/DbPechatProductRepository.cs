using TorgObject.ApplicationServices.Ports.Gateways.Database;
using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TorgObject.ApplicationServices.Repositories
{
    public class DbPechatProductRepository : IReadOnlyPechatProductRepository,
                                     IPechatProductRepository
    {
        private readonly ITorgDatabaseGateway _databaseGateway;

        public DbPechatProductRepository(ITorgDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<PechatProduct> GetPechatProduct(long id)
            => await _databaseGateway.GetPechatProduct(id);

        public async Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
            => await _databaseGateway.GetAllPechatProducts();

        public async Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria)
            => await _databaseGateway.QueryPechatProducts(criteria.Filter);

        public async Task AddPechatProduct(PechatProduct pechatproduct)
            => await _databaseGateway.AddPechatProduct(pechatproduct);

        public async Task RemovePechatProduct(PechatProduct pechatproduct)
            => await _databaseGateway.RemovePechatProduct(pechatproduct);

        public async Task UpdatePechatProduct(PechatProduct pechatproduct)
            => await _databaseGateway.UpdatePechatProduct(pechatproduct);
    }
}
