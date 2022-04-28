
namespace CreditCards.Core.Interfaces
{
    using System.Threading.Tasks;

    using CreditCards.Core.Model;

    public interface ICreditCardApplicationRepository
    {
        Task AddAsync(CreditCardApplication application);
    }
}
