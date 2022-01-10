using System;

namespace bug_tracker.Models
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
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

    }
}