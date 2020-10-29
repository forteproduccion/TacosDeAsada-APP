using Refit;
using System.Threading.Tasks;

namespace Cotemar.Api
{
    public interface IPostRest<ENTITY>
    {
        [Post("/Post")]
        [Headers("Authorization: Bearer")]
        Task<long> Post([Body] ENTITY item);
    }
}
