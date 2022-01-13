using System.Collections.Generic;

namespace bug_tracker.Models
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Create(TEntity data);
        Dictionary<string, object> UpdateWithoutNull(TEntity data, bool forceFill = false);
        TEntity Update(TEntity data, bool forceFill = false);

        void AddColumnGuard<TGuardEntity>(TGuardEntity entity, string column){}
    }
}