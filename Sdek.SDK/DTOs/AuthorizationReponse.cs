using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.DTOs
{
    /// <summary>
    /// Форма ответа на авторизацию
    /// </summary>
    /// <see cref="https://api-docs.cdek.ru/29923918.html"/>
    public class AuthorizationResponse
    {
        /// <summary>
        /// JWT
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Тип токена (всегда принимает значение "bearer");
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// Срок действия токена (по умолчанию 3600 секунд);
        /// </summary>
        public long expires_in { get; set; }

        /// <summary>
        /// Область действия токена (доступ к объектам и операциям над ними);
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// Уникальный идентификатор токена.
        /// </summary>
        public string jti { get; set; }
    }
}
