using System;

namespace Lab5
{
    public interface IUserRepository
    {
        bool CheckPassword(string userName, string password);
    }

    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(Exception exception);
    }

    public interface IUserManager
    {
        void Login(string userName, string password);
        void Logout(string userName);
    }
}
