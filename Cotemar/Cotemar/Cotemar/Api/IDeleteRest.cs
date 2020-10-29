using Refit;
using System.Threading.Tasks;

namespace Cotemar.Api
{
    public interface IDeleteRest<ENTITY>
    {
        [Delete("/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(long id);
    }
}
