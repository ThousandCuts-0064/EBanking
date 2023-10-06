using System.Diagnostics.CodeAnalysis;
using EBanking.Data.Entities;

namespace EBanking.UI;

internal static class Comparers
{
    public static IEqualityComparer<User> UserRegister { get; } = new UserRegisterComparer();
    public static IEqualityComparer<User> UserLogin { get; } = new UserLoginComparer();

    private class UserRegisterComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y) => x?.Username == y?.Username;
        public int GetHashCode([DisallowNull] User obj) => obj.Username.GetHashCode();
    }

    private class UserLoginComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y) => x?.Username == y?.Username && x?.Password == y?.Password;
        public int GetHashCode([DisallowNull] User obj) => obj.Username.GetHashCode() ^ obj.Password.GetHashCode();
    }
}
