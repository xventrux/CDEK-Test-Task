using MyApp.Contracts.DTOs;
using Sdek.SDK.DTOs;
using Sdek.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.AppServices.Services.SdecServices
{
    public class CdecService : ICdecService
    {
        private readonly CdekClient _cdek;
        public CdecService(CdekClient cdek)
        {
            _cdek = cdek;
        }

        public async Task<CalculationByTariffCodeResponse> CalculateDeliveryAsync(CalculateDeliveryRequest request)
        {
            await CheckAndAuthAsync();

            GetCitiesCollectionResponse? senderCity = (await _cdek.GetCitiesCollectionAsync(new GetCitiesCollectionRequest()
            {
                fias_guid = request.FIASSenderCity
            })).SingleOrDefault();

            if (senderCity is null) throw new Exception("Не удалось определить город отправителя");

            GetCitiesCollectionResponse? receivingCity = (await _cdek.GetCitiesCollectionAsync(new GetCitiesCollectionRequest()
            {
                fias_guid = request.FIASReceivingCity
            })).SingleOrDefault();

            if (receivingCity is null) throw new Exception("Не удалось определить город получателя");


            CalculationByTariffCodeResponse response = await _cdek.CalculationByTariffCode(new CalculationByTariffCodeRequest()
            {
                from_location = new Location() { code = senderCity.code },
                to_location = new Location() { code = receivingCity.code },
                packages = new List<Package>()
                {
                    new Package()
                    {
                        height = request.Height / 10,
                        weight = request.Weight / 10,
                        width = request.Width / 10,
                        length = request.Length / 10
                    }
                },
                type = 2
            });

            return response;



        }

        /// <summary>
        /// Проверят, и, при необходимости проходит авторизацию
        /// </summary>
        /// <returns></returns>
        private async Task CheckAndAuthAsync()
        {
            if (!_cdek.IsAuth)
            {
                await _cdek.AuthAsync(new AuthorizationRequest()
                {
                    client_id = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI",
                    client_secret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG",
                    grant_type = "client_credentials"
                });
            }
        }
    }
}
