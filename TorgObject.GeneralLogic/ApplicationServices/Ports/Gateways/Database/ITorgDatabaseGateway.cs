using TorgObject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObject.ApplicationServices.Ports.Gateways.Database
{
    public interface ITorgDatabaseGateway
    {
        Task AddPechatProduct(PechatProduct pechatproduct);

        Task RemovePechatProduct(PechatProduct pechatproduct);

        Task UpdatePechatProduct(PechatProduct pechatproduct);

        Task<PechatProduct> GetPechatProduct(long id);

        Task<IEnumerable<PechatProduct>> GetAllPechatProducts();

        Task<IEnumerable<PechatProduct>> QueryPechatProducts(Expression<Func<PechatProduct, bool>> filter);

    }
}
