using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cotemar.Settings;

namespace Cotemar.Api
{
    public class PutRest<ENTITY> : IPutRest<ENTITY> where ENTITY : new()
    {
        private readonly IPutRest<ENTITY> put;

        public PutRest()
        {
            var url = $"{AppConfiguration.Values.BaseUrl}/{typeof(ENTITY).Name}";
            put = RestService.For<IPutRest<ENTITY>>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(url) }, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CustomResolver() })
            });
        }

        public Task<long> Put(long id, [Body] ENTITY item)
        {
            return put.Put(id, item);
        }
    }
}
