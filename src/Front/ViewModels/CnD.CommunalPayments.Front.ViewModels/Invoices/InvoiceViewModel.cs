using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Front.ViewModels.Invoices;

public class InvoiceViewModel
{
    /// <summary>
    /// Период
    /// </summary>
    [Required(ErrorMessage = "Необходимо выбрать период!")]
    public string IdPeriod { get; set; } = "";

    /// <summary>
    /// Поставщик услуг
    /// </summary>
    [Required(ErrorMessage = "Необходимо выбрать поставщика!")]
    public string IdProvider { get; set; } = "";

    /// <summary>
    /// Сумма квитанции
    /// </summary>
    [Required(ErrorMessage = "Необходимо указать сумму квитанции!")]
    [Range(0, 1000000, ErrorMessage = "Сумма должна быть неотрицательным числом!")]
    public decimal InvoiceSum { get; set; }
}
