using CRMWPFUserInterface.Models;
using System.Threading.Tasks;

namespace CRMWPFUserInterface.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}