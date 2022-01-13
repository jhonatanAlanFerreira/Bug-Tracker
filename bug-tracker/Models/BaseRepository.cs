using System;
using System.Collections.Generic;
using bug_tracker.Utils;

namespace bug_tracker.Models
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private List<string> ColumnsGuard = new List<string>();
        protected readonly AppDbContext _appDbContext;
        protected void AddColumnGuard<TGuardEntity>(string column)
        {
            if (typeof(TGuardEntity).GetProperty(column) == null) throw new Exception("A coluna " + column + " não existe em " + typeof(TGuardEntity));
            ColumnsGuard.Add(column);
        }
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

        public Dictionary<string, object> UpdateWithoutNull(TEntity data, bool forceFill = false)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                TEntity entity = new TEntity { Id = data.Id };
                var dictionaryData = ClassToDictionary.ToDictionary<TEntity>(data);

                if (!forceFill) ColumnsGuard.ForEach(column =>
                 {
                     dictionaryData.Remove(column);
                 });

                _appDbContext.Attach(entity);
                _appDbContext.Entry(entity).CurrentValues.SetValues(dictionaryData);
                _appDbContext.SaveChanges();

                return dictionaryData;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} não foi atualizado: {ex.Message}");
            }
        }

        public TEntity Update(TEntity data, bool forceFill = false)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                if (!forceFill) ColumnsGuard.ForEach(column =>
                {
                    data.GetType().GetProperty(column).SetValue(data, null);
                });

                _appDbContext.Update(data);
                _appDbContext.SaveChanges();
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