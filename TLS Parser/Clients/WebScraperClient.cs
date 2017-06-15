using System.Text;

namespace TLS_Parser.Clients
{
    /// <summary>
    /// Представление клиента для сайта WebScrapper
    /// </summary>
    public sealed class WebScraperClient : BaseClient
    {
        #region CONSTRUCTORS
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="siteEncoding">Кодировка сайта</param>
        public WebScraperClient(Encoding siteEncoding):
            base(siteEncoding)
        {
        }
        #endregion

        #region PROTECTED METHODS
        protected override void InitRequest(string url, string method)
        {
            base.InitRequest(url, method);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
        }
        #endregion

    }
}
