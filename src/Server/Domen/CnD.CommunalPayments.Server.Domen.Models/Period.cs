using CnD.CommunalPayments.Server.Domen.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Период счета
/// </summary>
public class Period
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; set; } = string.Empty;

    /// <summary>
    /// Название месяца
    /// </summary>
    public MonthName Month { get; set; }

    public override string ToString()
    {
        return $"{Month} {Year}";
    }
}

public enum MonthName
{
    [Display(Name = "Не выбран")]
    None = 0,

    [Display(Name = "Январь")]
    January = 1,

    [Display(Name = "Февраль")]
    February = 2,

    [Display(Name = "Март")]
    March = 3,

    [Display(Name = "Апрель")]
    April = 4,

    [Display(Name = "Май")]
    May = 5,

    [Display(Name = "Июнь")]
    June = 6,

    [Display(Name = "Июль")]
    Jule = 7,

    [Display(Name = "Август")]
    August = 8,

    [Display(Name = "Сентябрь")]
    September = 9,

    [Display(Name = "Октябрь")]
    October = 10,

    [Display(Name = "Ноябрь")]
    November = 11,

    [Display(Name = "Декабрь")]
    December = 12
}