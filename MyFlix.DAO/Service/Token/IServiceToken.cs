using Microsoft.AspNetCore.Identity;
using MyFlix.DAO.Models;

namespace MyFlix.DAO.IService
{
	public interface IServiceToken
    {
        DateTime GetExpiryTimestamp(string accessToken);
        string GenerateToken(IdentityUser user, List<string> currentRoles);
    }
}
