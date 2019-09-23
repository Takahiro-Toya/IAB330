using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class PlaceApi {

        private static HttpClient Client {get; set;}
        private static string apiKey = "AIzaSyDfjL46PjmrBTFtphRVTVIQ-E59m4tHBlk";


        public PlaceApi()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/");
        }

        /// <summary>
        /// Gets stores of a certain category near the specified co-ordinates. Can be show only
        /// open stores or all stores.
        /// </summary>
        /// <param name="latitude">Latitude of user.</param>
        /// <param name="longitude">Longitude of user.</param>
        /// <param name="category">Category of stores to find.</param>
        /// <param name="open">Should find only open stores.</param>
        async public Task<Response> GetPlaces(double latitude, double longitude, PlaceType category, bool onlyOpen)
        {
            string url = null;
            if (onlyOpen)
            {
                url = String.Format("nearbysearch/json?key={0}&location={1},{2}&sensor=true&rankby=distance&types={3}&opennow", apiKey, latitude, longitude, category.ToString());
            }
            else
            {
                url = String.Format("nearbysearch/json?key={0}&location={1},{2}&sensor=true&rankby=distance&types={3}", apiKey, latitude, longitude, category.ToString());
            }
            try
            {
                var resp = await Client.GetAsync(url).ConfigureAwait(false);
                if (resp.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(Response)) as Response;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get full details of specified place ID.
        /// </summary>
        /// <param name="placeId">ID of place.</param>
        async public static Task<Detail> GetDetails(string placeId)
        {
            try
            {
                var resp = await Client.GetAsync(String.Format("details/json?key={0}&placeid={1}&sensor=true", apiKey, placeId));
                if (resp.IsSuccessStatusCode)
                {
                    return (JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(Response)) as Response).Detail;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    } // end of class
} // end of name space

