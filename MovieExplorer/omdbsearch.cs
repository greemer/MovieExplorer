using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer
{
    class OmdbSearch
    {
        public async static Task<SearchRootObject> SearchMovie(string search)
        {
            var http = new HttpClient();

            var url = String.Format("http://www.omdbapi.com/?apikey=ff21610b&s={0}", search);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SearchRootObject));

            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));

            var data  = (SearchRootObject)serializer.ReadObject(ms);

            ///ms.Position = 0;
            ///SearchRootObject first = (SearchRootObject)serializer.ReadObject(ms);
            return data;
        }

        [DataContract]
        public class Search
        {
            [DataMember]
            public string Title { get; set; }

            [DataMember]
            public string Year { get; set; }

            [DataMember]
            public string imdbID { get; set; }

            [DataMember]
            public string Type { get; set; }

            [DataMember]
            public string Poster { get; set; }
        }

        [DataContract]
        public class SearchRootObject
        {
            [DataMember]
            public List<Search> Search { get; set; }

            [DataMember]
            public string totalResults { get; set; }

            [DataMember]
            public string Response { get; set; }
        }
    }
}
