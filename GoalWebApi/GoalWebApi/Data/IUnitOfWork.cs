using System.Threading.Tasks;
namespace GoalWebApi.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
