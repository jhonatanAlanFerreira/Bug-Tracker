using System;
using bug_tracker.Utils;

namespace bug_tracker.Models
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public TEntity Create(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                _appDbContext.Add(data);
                _appDbContext.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} falhou ao salvar: {ex.Message}");
            }
        }

        public TEntity Update(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                TEntity entity = new TEntity { Id = data.Id };
                var notNullData = ClassToDictionary.ToDictionary<TEntity>(data);

                _appDbContext.Attach(entity);
                _appDbContext.Entry(entity).CurrentValues.SetValues(notNullData);
                _appDbContext.SaveChanges();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} não foi atualizado: {ex.Message}");
            }
        }
    }
}