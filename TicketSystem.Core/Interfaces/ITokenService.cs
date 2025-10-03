using TicketSystem.Core.Models;

namespace TicketSystem.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(object user, string role);
    }
}
