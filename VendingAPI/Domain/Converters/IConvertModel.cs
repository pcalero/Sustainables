using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingAPI.Domain.Converters
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert();
    }
}
