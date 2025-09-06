using System.Security.Cryptography;
using System.Text;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public static class HashService
    {
        public static byte[] GetHash(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            return SHA256.HashData(textBytes);
        }
    }
}
