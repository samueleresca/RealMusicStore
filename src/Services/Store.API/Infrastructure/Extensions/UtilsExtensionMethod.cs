using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.API.Models;

namespace Store.API.Infrastructure.Extensions
{
    public static class UtilsExtensionMethod
    {
        public static IEnumerable<StoreViynl> Paginate(this IEnumerable<StoreViynl> collection, int pageIndex,
            int pageSize) => collection.Skip(pageSize * pageIndex).Take(pageSize);
    }
}
