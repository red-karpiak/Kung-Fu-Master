using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authenticationHeaderValue);
        }

        public async Task<string> GetData()
        {
            PatternLines = new List<PatternLine>();

            //rest url
            var uri = new Uri(String.Format(Constants.weburl, string.Empty));
            var content = "";
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                    PatternLines = JsonConvert.DeserializeObject<List<PatternLine>>(content);
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\n\n\n" + e.InnerException.Message + "\n\n\n");
            }
            return content;
        }

        public Task SavePatternLine(PatternLine line)
        {
            throw new NotImplementedException();
        }

        public Task DeletePatternLine(int id)
        {
            throw new NotImplementedException();
        }
    }
}
