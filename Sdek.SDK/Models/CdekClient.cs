using Sdek.SDK.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.Models
{
    public class CdekClient
    {
        private const string _productionUri = "https://api.cdek.ru/v2";
        private const string _sandboxUri = "https://api.edu.cdek.ru/v2";

        /// <summary>
        /// Ответ на авторизацию
        /// </summary>
        public AuthorizationResponse AuthorizationResponse { get; private set; }

        /// <summary>
        /// Выполнена ли авторизация
        /// </summary>
        public bool IsAuth { get => AuthorizationResponse is not null && !String.IsNullOrEmpty(AuthorizationResponse?.access_token); }

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="request">Данные для авторизации</param>
        public async Task AuthAsync(AuthorizationRequest request)
        {
            using(HttpClient client = new HttpClient())
            {
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>(nameof(AuthorizationRequest.grant_type), request.grant_type));
                nvc.Add(new KeyValuePair<string, string>(nameof(AuthorizationRequest.client_id), request.client_id));
                nvc.Add(new KeyValuePair<string, string>(nameof(AuthorizationRequest.client_secret), request.client_secret));

                using (var req = new HttpRequestMessage(HttpMethod.Post, $"{_sandboxUri}/oauth/token?parameters") { Content = new FormUrlEncodedContent(nvc) })
                using (var res = await client.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();

                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                    AuthorizationResponse = await res.Content.ReadFromJsonAsync<AuthorizationResponse>();
                }
            }
        }

        /// <summary>
        /// Метод получения списка населенных пунктов
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<GetCitiesCollectionResponse>> GetCitiesCollectionAsync(GetCitiesCollectionRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationResponse.access_token);

                var result = await client.GetAsync($"{_sandboxUri}/location/cities/?fias_guid={request.fias_guid}");
                result.EnsureSuccessStatusCode();

                if(result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadFromJsonAsync<List<GetCitiesCollectionResponse>>();
                }
                throw new Exception($"Ошибка: {result.StatusCode}");

            }
        }

        public async Task<CalculationByTariffCodeResponse> CalculationByTariffCode(CalculationByTariffCodeRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationResponse.access_token);

                var jsonContent = JsonContent.Create<CalculationByTariffCodeRequest>(request);

                var result = await client.PostAsync($"{_sandboxUri}/calculator/tarifflist", jsonContent);
                result.EnsureSuccessStatusCode();

                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadFromJsonAsync<CalculationByTariffCodeResponse>();
                }
                throw new Exception($"Ошибка: {result.StatusCode}");
            }
        }
    }
}
