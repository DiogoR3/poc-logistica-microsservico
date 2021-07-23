using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.Web.Services
{
    public class HttpService
    {
        public async static Task<(HttpStatusCode, string)> HttpRequestAsync(string url, HttpMethod httpMethod, string authHeader, object body = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = httpMethod.ToString();

            if(!string.IsNullOrEmpty(authHeader))
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, authHeader);

            if(body is not null)
            {
                using StreamWriter streamWriter = new(httpWebRequest.GetRequestStream());
                string json = JsonSerializer.Serialize(body);
                streamWriter.Write(json);
            }

            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string responseText = await streamReader.ReadToEndAsync();
                return (httpResponse.StatusCode, responseText);
            }
            catch (WebException ex)
            {
                return (((HttpWebResponse)ex.Response)?.StatusCode ?? HttpStatusCode.InternalServerError, null);
            }
            catch (Exception ex)
            {
                return (HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
