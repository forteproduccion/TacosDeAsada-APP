using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cotemar.Settings;

namespace Cotemar.Api
{
    public class DeleteRest<ENTITY> : IDeleteRest<ENTITY> where ENTITY : new()
    {
        private readonly IDeleteRest<ENTITY> delete;

        public DeleteRest()
        {
            var url = $"{AppConfiguration.Values.BaseUrl}/{typeof(ENTITY).Name}";
            delete = RestService.For<IDeleteRest<ENTITY>>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(url) }, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CustomResolver() })
            });
        }

        public Task<bool> Delete(long id)
        {
            return delete.Delete(id);
        }
    }
}
