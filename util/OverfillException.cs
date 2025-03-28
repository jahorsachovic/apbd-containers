namespace ApbdContainers.util;

[Serializable]
public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }

    public OverfillException(string message, Exception innerException) : base(message, innerException)
    {
    }
}