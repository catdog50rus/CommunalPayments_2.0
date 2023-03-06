using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Front.ViewModels.Periods;

public class PeriodListItemViewModel
{
    public int Id { get; set; }

    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; set; }

    /// <summary>
    /// Название месяца
    /// </summary>
    public string Month { get; set; }
}
