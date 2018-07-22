using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer
{
    class OmdbData
    {
        public async static Task<RootObject> GetMovie(double lat, double lon)
        {
            var http = new HttpClient();
            ///var url = String.Format("http://www.omdbapi.com/?apikey=ff21610b&t=social+network", lat, lon);
            var url = String.Format("http://www.omdbapi.com/?apikey=ff21610b&t={0}", "social network");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RootObject));

            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }

    public class Rating
        {
            public string Source { get; set; }
            public string Value { get; set; }
        }

    public class RootObject
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Rated { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Plot { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
            public List<Rating> Ratings { get; set; }
            public string Metascore { get; set; }
            public string ImdbRating { get; set; }
            public string ImdbVotes { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string DVD { get; set; }
            public string BoxOffice { get; set; }
            public string Production { get; set; }
            public string Website { get; set; }
            public string Response { get; set; }

    }
}
