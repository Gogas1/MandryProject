namespace Mandry.Interfaces.Helpers
{
    public interface IStringObfuscator
    {
        string ObfuscateEmail(string email);
        string ObfuscatePhone(string phone);
    }
}
