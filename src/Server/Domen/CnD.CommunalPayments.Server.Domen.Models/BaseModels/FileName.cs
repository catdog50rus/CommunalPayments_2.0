using CnD.CommunalPayments.Server.Domen.Models.BaseModels.Base;

namespace CnD.CommunalPayments.Server.Domen.Models.BaseModels;

public class FileName : IProperty<string>
{
	private readonly string _filename;

    public string Value => _filename;

    public FileName(string filename)
	{
		_filename = filename;
	}

    public string GetValue()
    {
        throw new NotImplementedException();
    }

    private void Validate(string filename)
    {
        if (string.IsNullOrEmpty(filename))
            throw new ArgumentNullException("filename", "Имя файла не может быть пустым");
    }
}