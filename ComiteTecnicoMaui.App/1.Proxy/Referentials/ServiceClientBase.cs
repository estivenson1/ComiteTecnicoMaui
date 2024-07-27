using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Referentials;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App._1.Proxy.Referentials;

public class ServiceClientBase<T> where T : class, new()
{

    protected string ServiceUrl { get; set; } = "https://restcountries.com/v3.1/all";

    protected HttpClient GetHttpClient()
    {
        HttpClient httpClient = new HttpClient();
        return httpClient;
    }

    public async Task<ResponseBack<T>> Get()
    {
        try
        {
            var result = new ResponseBack<T>();
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = await client.GetAsync(ServiceUrl);


            string responseString = string.Empty;
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responseString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseBack<T>>(responseString);
            }
            else
            {
                result = new ResponseBack<T>
                {
                    TransactionComplete = false,
                    ResponseCode = (int)response.StatusCode
                };
            }

            return result;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            return new ResponseBack<T>
            {
                TransactionComplete = false,
                ResponseCode = (int)System.Net.HttpStatusCode.Forbidden
            };
        }

    }

    public async Task<ResponseBack<T>> GetJArray()
    {
        try
        {
            var result = new ResponseBack<T>();
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = await client.GetAsync(ServiceUrl);

            string responseString = string.Empty;
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responseString = await response.Content.ReadAsStringAsync();
                result.MyJArray = JArray.Parse(responseString);
                result.TransactionComplete = true;
            }
            else
            {
                result = new ResponseBack<T>
                {
                    TransactionComplete = false,
                    ResponseCode = (int)response.StatusCode
                };
            }

            return result;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            return new ResponseBack<T>
            {
                TransactionComplete = false,
                ResponseCode = (int)System.Net.HttpStatusCode.Forbidden
            };
        }

    }


}

