using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}