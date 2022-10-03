using CnD.CommunalPayments.Server.Domen.Models.BaseModels.Base;

namespace CnD.CommunalPayments.Server.Domen.Models.BaseModels;

public class WebSite : IProperty<string>
{
	private readonly string _webSite;

    public string Value => _webSite;

    public WebSite(string webSite)
	{
		_webSite = webSite.ToLower()?? string.Empty;
	}

	public string GetValue()
	{
		return _webSite;
	}
}