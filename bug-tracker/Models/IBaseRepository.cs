using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Create(TEntity data);
        TEntity Update(TEntity data);
    }
}