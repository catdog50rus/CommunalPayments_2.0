namespace CnD.CommunalPayments.Contracts.Models.Providers.Request
{
    public class CreateProviderRequest
    {
        /// <summary>
        /// Наименование поставщика услуги ЖКХ
        /// </summary>
        public string NameProvider { get; set; }

        /// <summary>
        /// Путь к личному кабинету поставщика
        /// </summary>
        public string WebSite { get; set; }
    }
}