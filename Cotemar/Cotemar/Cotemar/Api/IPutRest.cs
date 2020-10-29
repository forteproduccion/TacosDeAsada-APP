using Refit;
using System.Threading.Tasks;

namespace Cotemar.Api
{
    public interface IPutRest<ENTITY>
    {
        [Put("/Put")]
        [Headers("Authorization: Bearer")]
        Task<long> Put(long id, [Body] ENTITY item);
    }
}
