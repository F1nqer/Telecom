using Application.ViewModels;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProviderService
    {
        public string AddBalance(Payment payment);
        public Task<string> AddBalanceAsync(Payment payment);
    }
}