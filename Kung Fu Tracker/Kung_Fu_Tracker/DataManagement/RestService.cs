﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Kung_Fu_Tracker.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Kung_Fu_Tracker.DataManagement
{
    public class RestService
    {
        HttpClient httpClient;
        string grant_type = "password";
        public RestService()
        {
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }
        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.weburl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expireDate = dt.AddSeconds(response.expireIn);
            return response;
        }
        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await httpClient.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }
        public async Task<T> PostResponse<T>(string weburl, string jsonContent) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            string contentType = "application/json";
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
            try
            {
                var result = await httpClient.PostAsync(weburl, new StringContent(jsonContent, Encoding.UTF8, contentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
            try
            {
                var response = await httpClient.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("JsonResult: " + jsonResult);
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
