using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments.Server.Domen.Models;

public class Period
{
    public int Id { get; set; }

    public string Year { get; set; } = string.Empty;

    public PeriodsName Month { get; set; }
}

public enum PeriodsName
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