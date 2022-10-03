namespace CnD.CommunalPayments.Contracts.Models.Providers.Request
{
    public class UpdateProviderRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
