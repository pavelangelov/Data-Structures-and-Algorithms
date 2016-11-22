namespace Utils.Contracts
{
    public interface ILogger
    {
        void Write(string text);

        void WriteLine();

        void WriteLine(string text);
    }
}
