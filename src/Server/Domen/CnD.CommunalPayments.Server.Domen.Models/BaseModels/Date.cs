using CnD.CommunalPayments.Server.Domen.Models.BaseModels.Base;

namespace CnD.CommunalPayments.Server.Domen.Models.BaseModels;

public class Date : IProperty<DateOnly>
{
	private readonly DateOnly _date;

    public DateOnly Value => _date;

    public Date(string date)
	{
		_date = Validate(date);
    }

	public DateOnly GetValue()
	{
		throw new NotImplementedException();
	}

	private DateOnly Validate(string strDate)
	{
		if (!DateOnly.TryParse(strDate, out DateOnly date))
			throw new ArgumentException("Строка не может быть преобразована в дату", "Date");

		if(date.Year < DateTime.Now.AddYears(-100).Year || date.Year > DateTime.Now.AddYears(1).Year)
            throw new ArgumentOutOfRangeException("Date");

		return date;
    }
}
