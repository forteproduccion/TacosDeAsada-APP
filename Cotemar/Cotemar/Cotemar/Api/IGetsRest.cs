using Refit;
using System.Threading.Tasks;

namespace Cotemar.Api
{
    public interface IGetsRest<ENTITY, BASE_RESPONCE>
    {
        [Get("/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<BASE_RESPONCE> GetAll();

        [Get("/Get")]
        [Headers("Authorization: Bearer")]
        Task<ENTITY> Get(long id);

        [Get("/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<BASE_RESPONCE> ListaSelAll(long startRowIndex = 0, long maximumRows = 100, string where = null, string order = null);
    }
}
