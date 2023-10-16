namespace EBanking.Logic.Services;

public interface IEncryptionService
{
    public IEncryptionService Encrypt(string str, out string hash, out string salt);
    public string Compose(string hash, string salt);
    public IEncryptionService Decompose(string str, out string hash, out string salt);
    public bool Verify(string str, string hash, string salt);
}
