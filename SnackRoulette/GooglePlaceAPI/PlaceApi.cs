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

        async public Task<Response> GetPlaces(double latitude, double longitude, double radius, String type, String keyword, int priceLevel, bool onlyOpen)
        {
            string url = null;
            if (onlyOpen)
            {
                url = String.Format("nearbysearch/json?location={0},{1}&radius={2}&type={3}&keyword={4}&price_level={5}&key={6}&opennow", latitude, longitude, radius, type, keyword, priceLevel.ToString(), apiKey);
            }
            else
            {
                url = String.Format("nearbysearch/json?location={0},{1}&radius={2}&type={3}&keyword={4}&price_level={5}&key={6}", latitude, longitude, radius, type, keyword, priceLevel.ToString(), apiKey);
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
        /// Gets stores of a certain category near the specified co-ordinates. Can be show only
        /// open stores or all stores.
        /// </summary>
        /// <param name="latitude">Latitude of user.</param>
        /// <param name="longitude">Longitude of user.</param>
        /// <param name="category">Category of stores to find.</param>
        /// <param name="open">Should find only open stores.</param>
        async public Task<Response> GetPlaces(double latitude, double longitude, String category, bool onlyOpen)
        {
            string url = null;
            if (onlyOpen)
            {
                url = String.Format("nearbysearch/json?location={0},{1}&radius=1500&type={2}&key={3}&opennow", latitude, longitude, category, apiKey);
            }
            else
            {
                url = String.Format("nearbysearch/json?location={0},{1}&radius=1500&type={2}&key={3}", latitude, longitude, category, apiKey)  ;
                                    
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
                var resp = await Client.GetAsync(String.Format("details/json?key={0}&placeid={1}&sensor=true", apiKey, placeId)).ConfigureAwait(false);
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

