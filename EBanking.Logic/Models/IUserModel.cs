namespace EBanking.Logic.Models;

public interface IUserModel
{
    public string FullName { get; }

    public IReadOnlyList<IUserAccountModel> UserAccounts { get; }
}
