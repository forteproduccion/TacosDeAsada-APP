using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cotemar.Settings;

namespace Cotemar.Api
{
    public class PostRest<ENTITY> : IPostRest<ENTITY> where ENTITY : new()
    {
        private readonly IPostRest<ENTITY> post;

        public PostRest()
        {
            var url = $"{AppConfiguration.Values.BaseUrl}/{typeof(ENTITY).Name}";
            post = RestService.For<IPostRest<ENTITY>>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(url) }, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CustomResolver() })
            });
        }

        public Task<long> Post([Body] ENTITY item)
        {
            return post.Post(item);
        }
    }
}
