using MyApp.Contracts.DTOs;
using Sdek.SDK.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.AppServices.Services.SdecServices
{
    /// <summary>
    /// Сервис для работы со СДЭК
    /// </summary>
    public interface ICdecService
    {
        /// <summary>
        /// Расчет стоимости доставки по тарифам
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CalculationByTariffCodeResponse> CalculateDeliveryAsync(CalculateDeliveryRequest request);

    }
}
