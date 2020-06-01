using System.Threading.Tasks;
using System.Collections.Generic;
using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using TorgObject.ApplicationServices.Ports;

namespace TorgObject.ApplicationServices.GetPechatProductListUseCase
{
    public class GetPechatProductListUseCase : IGetPechatProductListUseCase
    {
        private readonly IReadOnlyPechatProductRepository _readOnlyPechatProductRepository;

        public GetPechatProductListUseCase(IReadOnlyPechatProductRepository readOnlyPechatProductRepository)
            => _readOnlyPechatProductRepository = readOnlyPechatProductRepository;

        public async Task<bool> Handle(GetPechatProductListUseCaseRequest request, IOutputPort<GetPechatProductListUseCaseResponse> outputPort)
        {
            IEnumerable<PechatProduct> pechatproducts = null;
            if (request.PechatProductId != null)
            {
                var pechatproduct = await _readOnlyPechatProductRepository.GetPechatProduct(request.PechatProductId.Value);
                pechatproducts = (pechatproduct != null) ? new List<PechatProduct>() { pechatproduct } : new List<PechatProduct>();

            }
            else if (request.District != null)
            {
                pechatproducts = await _readOnlyPechatProductRepository.QueryPechatProducts(new DistrictCriteria(request.District));
            }
            else
            {
                pechatproducts = await _readOnlyPechatProductRepository.GetAllPechatProducts();
            }
            outputPort.Handle(new GetPechatProductListUseCaseResponse(pechatproducts));
            return true;
        }
    }
}
