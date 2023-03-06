namespace CnD.CommunalPayments.Front.ViewModels.Periods;

public class Period : ModelBase
{
    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; set; }

    /// <summary>
    /// Название месяца
    /// </summary>
    public string Month { get; set; }

    public override string ToString()
    {
        return $"{Month} {Year}";
    }
}