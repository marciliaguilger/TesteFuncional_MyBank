using System.Threading.Tasks;

namespace MyBank.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
