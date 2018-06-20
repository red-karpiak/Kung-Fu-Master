using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kung_Fu_Tracker.Models;
using Newtonsoft.Json;

namespace Kung_Fu_Tracker.DataManagement
{
    public class RestService// : IRestService
    {
        HttpClient client;

        //Generizise after working with pattern line
        public List<PatternLine> PatternLines { get; private set; }

        //add user authentication class from here: https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/basic-authentication
        public RestService()
        {
            var authentication = string.Format("{0}:{1}", App.LoggedInUser.Username, App.LoggedInUser.Password);
            var authenticationHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authentication));

            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authenticationHeaderValue);
        }

        public async Task<string> GetData(string rank = null)
        {
            PatternLines = new List<PatternLine>();
            string uriString = Constants.WebUrl;
            if (!string.IsNullOrEmpty(rank))
                uriString += "/?Rank=" + rank;
            //rest url
            var uri = new Uri(String.Format(uriString, string.Empty));
            var content = "";
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n\n\n" + e.Message + "\n\n\n");
            }
            return content;
        }

        public async Task SavePatternLine(PatternLine line, bool isNewLine = false)
        {
            Uri uri;

            try
            {
                var json = JsonConvert.SerializeObject(line);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewLine)
                {
                    uri = new Uri(string.Format(Constants.patternLinePostString, line.LeftHand, line.RightHand));
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(string.Format(Constants.patternLinePutString, line.ID, line.LeftHand, line.RightHand));
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Pattern Line successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR {0}", ex.Message);
            }
        }

        public async Task DeletePatternLine(int id)
        {
            var uri = new Uri(string.Format(Constants.patternLineDeleteString, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Pattern Line successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR {0}", ex.Message);
            }
        }
    }
}
