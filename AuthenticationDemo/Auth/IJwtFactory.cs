using System.Threading.Tasks;
using AuthenticationDemo.Models;

namespace AuthenticationDemo.Auth
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}