using System.Collections.Generic;

namespace PromotionEngine.Database
{
    public interface IConfigDetails<T>
    {
        List<T> Get();
    }
}
