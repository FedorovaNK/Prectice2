using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TorgObject.ApplicationServices.GetPechatProductListUseCase
{
    public class DistrictCriteria : ICriteria<PechatProduct>
    {
        public string District { get; }

        public DistrictCriteria(string district)
            => District = district;

        public Expression<Func<PechatProduct, bool>> Filter
            => (ds => ds.District == District);
    }
}
