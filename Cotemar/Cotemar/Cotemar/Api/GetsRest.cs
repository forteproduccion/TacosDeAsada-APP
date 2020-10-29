using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cotemar.Settings;

namespace Cotemar.Api
{
    public class GetsRest<ENTITY, BASE_RESPONCE> : IGetsRest<ENTITY, BASE_RESPONCE> where ENTITY : new() where BASE_RESPONCE : new()
    {
        private readonly IGetsRest<ENTITY, BASE_RESPONCE> gets;

        public GetsRest()
        {
            var url = $"{AppConfiguration.Values.BaseUrl}/{typeof(ENTITY).Name}";
            gets = RestService.For<IGetsRest<ENTITY, BASE_RESPONCE>>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(url) }, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CustomResolver() })
            });
        }

        public Task<ENTITY> Get(long id)
        {
            return gets.Get(id);
        }

        public Task<BASE_RESPONCE> GetAll()
        {
            return gets.GetAll();
        }

        public Task<BASE_RESPONCE> ListaSelAll(long startRowIndex = 0, long maximumRows = 100, string where = null, string order = null)
        {
            return gets.ListaSelAll(startRowIndex, maximumRows, where, order);
        }
    }
}
