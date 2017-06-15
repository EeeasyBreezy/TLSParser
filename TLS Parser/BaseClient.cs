using System.Net;
using System.Text;
using System.IO;

namespace TLS_Parser
{
    /// <summary>
    /// Базовое представление для web-клиента
    /// </summary>
    public class BaseClient
    {
        #region DATA
        protected HttpWebRequest request;
        protected HttpWebResponse response;
        protected CookieContainer container;
        protected string responseText;
        protected string requestBody;
        protected Encoding siteEncoding;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Конструктор 
        /// </summary>
        public BaseClient()
        {
        }
        /// <summary>
        /// Конструтор
        /// </summary>
        /// <param name="siteEncoding">Кодировка сайта</param>
        public BaseClient(Encoding siteEncoding)
        {
            this.siteEncoding = siteEncoding;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Послать запрос методм GET
        /// </summary>
        /// <param name="uri">Адрес ресурса в сети</param>
        /// <returns>Текст ответа</returns>
        public virtual string NavigateGet(string uri)
        {
            InitRequest(uri, "GET");
            ManageCookies();
            GetResponse();
            SaveCookies();
            return responseText;
        }
        /// <summary>
        /// Послать запрос методом POST
        /// </summary>
        /// <param name="uri">Адрес ресурса в сети</param>
        /// <param name="data">Данные для отправки</param>
        /// <returns></returns>
        public virtual string NavigatePost(string uri, string data)
        {
            InitRequest(uri, "POST");
            ManageCookies();
            requestBody = data;
            EncodeRequestBody();
            GetResponse();
            SaveCookies();
            return responseText;
        }
        #endregion

        #region PROTECTED METHODS
        /// <summary>
        /// Инициализировать запрос
        /// </summary>
        /// <param name="url">Адрес ресурса в сети</param>
        /// <param name="method">Метод отправки ресурса</param>
        protected virtual void InitRequest(string url, string method)
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            request.UserAgent = "Chrome/58.0.3029.110";
            request.KeepAlive = true;
        }
        /// <summary>
        /// Получить ответ
        /// </summary>
        protected virtual void GetResponse()
        {
            StreamReader reader = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                reader = new StreamReader(response.GetResponseStream());
            }
            finally
            {
                responseText = reader.ReadToEnd();
            }
        }
        /// <summary>
        /// Управление кукисами
        /// </summary>
        protected virtual void ManageCookies()
        {
            if (container != null)
                request.CookieContainer = container;
            else
                request.CookieContainer = new CookieContainer();
        }
        /// <summary>
        /// Сохранить кукисы
        /// </summary>
        protected virtual void SaveCookies()
        {
            if (request.CookieContainer.Count > 0)
                container = request.CookieContainer;
            if (response.Cookies.Count > 0)
                container.Add(response.Cookies);
        }
        /// <summary>
        /// Записать тело запроса
        /// </summary>
        protected virtual void EncodeRequestBody()
        {
            request.GetRequestStream().Write(siteEncoding.GetBytes(requestBody),
                0, requestBody.Length);
        }
        #endregion
    }
}
