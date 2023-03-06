namespace CnD.CommunalPayments.Front.ViewModels;

public class ModelId
{
    private readonly int _value = 0;

    public virtual int Value => _value;

    public ModelId(int id)
	{
		ValidateId(id);
        _value = id;
	}

    public virtual int GetValue()
    {
        return _value;
    }

    protected virtual void ValidateId(int value)
    {
        if (value < 0)
            throw new ArgumentException("Значение не может быть меньше 0", nameof(value));
    }

    public override bool Equals(object? obj)
    {
        if (obj is int value)
        {
            return _value == value;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _value.ToString().GetHashCode();
    }

    public override string ToString()
    {
        return $"{_value}";
    }
}