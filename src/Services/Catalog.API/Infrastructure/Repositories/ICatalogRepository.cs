using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Model;

namespace Catalog.API.Infrastructure.Repositories
{
    public interface ICatalogRepository
    {
        IQueryable<CatalogTrack> GetAll { get; }
        Task<CatalogTrack> Create(CatalogTrack entity);
        Task<CatalogTrack> Delete(int id);
        Task<CatalogTrack> GetById(int id);
        Task<CatalogTrack> Update(int id, CatalogTrack entity);
    }
}