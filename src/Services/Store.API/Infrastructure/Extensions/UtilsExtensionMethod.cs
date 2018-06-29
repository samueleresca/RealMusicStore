using System.Collections.Generic;
using System.Linq;

namespace Store.API.Infrastructure.Extensions
{
    public static class UtilsExtensionMethod
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, int pageIndex,
            int pageSize) => collection.Skip(pageSize * pageIndex).Take(pageSize);

    }
}
