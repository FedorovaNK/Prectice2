using TorgObject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TorgObject.ApplicationServices.Ports.Gateways.Database;

namespace TorgObject.InfrastructureServices.Gateways.Database
{
    public class TorgEFSqliteGateway : ITorgDatabaseGateway
    {
        private readonly TorgContext _torgContext;

        public TorgEFSqliteGateway(TorgContext TorgContext)
            => _torgContext = TorgContext;

        public async Task<PechatProduct> GetPechatProduct(long id)
           => await _torgContext.PechatProducts.Where(ds => ds.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
            => await _torgContext.PechatProducts.ToListAsync();

        public async Task<IEnumerable<PechatProduct>> QueryPechatProducts(Expression<Func<PechatProduct, bool>> filter)
            => await _torgContext.PechatProducts.Where(filter).ToListAsync();

        public async Task AddPechatProduct(PechatProduct pechatproduct)
        {
            _torgContext.PechatProducts.Add(pechatproduct);
            await _torgContext.SaveChangesAsync();
        }

        public async Task UpdatePechatProduct(PechatProduct pechatproduct)
        {
            _torgContext.Entry(pechatproduct).State = EntityState.Modified;
            await _torgContext.SaveChangesAsync();
        }

        public async Task RemovePechatProduct(PechatProduct pechatproduct)
        {
            _torgContext.PechatProducts.Remove(pechatproduct);
            await _torgContext.SaveChangesAsync();
        }

    }
}
