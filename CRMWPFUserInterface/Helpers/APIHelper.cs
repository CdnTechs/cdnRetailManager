﻿using CRMWPFUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRMWPFUserInterface.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient;
        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password)

            });
            using (HttpResponseMessage reponse = await apiClient.PostAsync("/Token", data))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    var result = await reponse.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }
    }
}
