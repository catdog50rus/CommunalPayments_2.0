using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Contracts.Models.Invoices.Response
{
    public class CreateInvoiceResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// Период за который выставлен счет
        /// </summary>
        public int PeriodId { get; set; }

        /// <summary>
        /// Id поставщика услуги
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Сумма счета
        /// </summary>
        public decimal Sum { get; set; }

        public bool Pay { get; set; }
    }
}