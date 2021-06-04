using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public interface IPromotions<T>
    {
        List<T> Get();
    }
}
