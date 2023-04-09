using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop
{
    class RequestMaker
    {
        private string controller;
        public RequestMaker(string controller)
        {

            this.controller = controller;
        }

        public async Task<HttpResponseMessage> MakeRequest(object? requestBody, Type? type, HttpMethod method, string route, bool useHeader = true)
        {
            StringContent? content = null;
            if (requestBody is not null)
            {
                var rb = Convert.ChangeType(requestBody, type);
                var jsonBody = JsonConvert.SerializeObject(rb);
                content = new(jsonBody, Encoding.UTF8, "application/json");
            }
            using (var httpClient = new HttpClient())
            {
                if (useHeader)
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {CurrentJWT.Token}");

                HttpRequestMessage request;
                if (content != null)
                {
                    request = new HttpRequestMessage
                    {
                        Method = method,
                        RequestUri = new Uri($"https://localhost:7216/api/{controller}/{route}"),
                        Content = content
                    };
                }
                else
                {
                    request = new HttpRequestMessage
                    {
                        Method = method,
                        RequestUri = new Uri($"https://localhost:7216/api/{controller}/{route}"),
                    };
                }

                return await httpClient.SendAsync(request);
            }
        }
    }
}
