namespace CnD.CommunalPayments.Server.Domen.Models;

public class Period
{
    public int IdKey { get; set; }
    public string Year { get; set; }
    public PeriodsName Month { get; set; }
}

public enum PeriodsName
{
    None,
    Январь,
    Февраль,
    Март,
    Апрель,
    Май,
    Июнь,
    Июль,
    Август,
    Сентябрь,
    Октябрь,
    Ноябрь,
    Декабрь
}