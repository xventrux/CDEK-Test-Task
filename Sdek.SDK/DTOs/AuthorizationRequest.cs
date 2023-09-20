using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.DTOs
{
    /// <summary>
    /// Форма запроса на авторизацию
    /// </summary>
    /// <see cref="https://api-docs.cdek.ru/29923918.html"/>
    public class AuthorizationRequest
    {
        /// <summary>
        /// Тип аутентификации, доступное значение: client_credentials;
        /// </summary>
        public string grant_type;

        /// <summary>
        /// Идентификатор клиента, равен Account;
        /// </summary>
        public string client_id;

        /// <summary>
        /// Секретный ключ клиента, равен Secure password.
        /// </summary>
        public string client_secret;
    }
}
