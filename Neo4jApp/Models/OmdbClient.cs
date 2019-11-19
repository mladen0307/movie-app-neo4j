using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public class OmdbClient:IOmdbClient
    {

        private readonly HttpClient _client;
       

        public OmdbClient(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = httpClient;
            
        }

        public async Task<MovieDetailsModel> LoadMovieByImdbIDAsync(string id)
        {

            string url = $"http://www.omdbapi.com/?i={id}&apikey=4aeaadbc";

            using (HttpResponseMessage response = await _client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MovieDetailsModel result = await response.Content.ReadAsAsync<MovieDetailsModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<MovieModel>> LoadMoviesAsync(string searchString)
        {

            searchString = searchString.Replace(" ", "+");
            string url = $"http://www.omdbapi.com/?s={searchString}&apikey=4aeaadbc";

            using (HttpResponseMessage response = await _client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MovieSearchResultModel result = await response.Content.ReadAsAsync<MovieSearchResultModel>();

                    return result.Search;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
