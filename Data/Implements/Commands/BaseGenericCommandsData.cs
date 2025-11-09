using Data.Implements.Base;
using Entity.Context.Main;
using Entity.Model.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Data.Implements.Commands
{
    public class BaseGenericCommandsData<T> : ABaseCommandData<T> where T : ABaseEntity
    {
        public BaseGenericCommandsData(AplicationDbContext context, ILogger<BaseGenericCommandsData<T>> logger) : base(context, logger)
        {
        }

        public override async Task<T> InsertAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity; 
            } catch (DbUpdateException ex) 
            {
                throw DbExceptionTranslator.ToBusiness(ex, "insert", typeof(T).Name);
            }
        }

        public override async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.UtcNow;

                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex) 
            {
                throw DbExceptionTranslator.ToBusiness(ex, "update", typeof(T).Name);
            }
        }

        public override async Task<bool> DeleteLogicalAsyn(int id, int status)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(T).Name, id);


            try
            {
                entity.Status = status;
                entity.DeleteAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return true;

            }
            catch(DbUpdateException ex) 
            {
                throw DbExceptionTranslator.ToBusiness(ex, "update", typeof(T).Name);
            }
        }
        public override async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(T).Name, id);

            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex) {

                throw DbExceptionTranslator.ToBusiness(ex, "delete", typeof(T).Name);

            }
        }

        //<summary>
        // Este metodo, recibe cualquier propiedad de modelo para actualizarlo, siempre se debe mandar el Id de la entiendad
        //</summary>
        public override async Task<T?> UpdatePartialAsync(T entity)
        {
            var dbEntity = await _dbSet.FindAsync(entity.Id);
            if (dbEntity == null) return null; // o null/throw según tu contrato

            var entry = _context.Entry(dbEntity);
            var et = _context.Model.FindEntityType(typeof(T))
                     ?? throw new InvalidOperationException($"Tipo {typeof(T).Name} no está en el modelo EF.");

            // Solo nombres de propiedades escalares mapeadas por EF (no navegaciones)
            var scalarNames = et.GetProperties().Select(p => p.Name).ToHashSet(StringComparer.Ordinal);

            // Marcar como Unchanged y tocar selectivamente
            entry.State = EntityState.Unchanged;

            foreach (var name in scalarNames)
            {
                // evita campos de sistema
                if (name is nameof(ABaseEntity.Id)
                        or nameof(ABaseEntity.CreatedAt)
                        or nameof(ABaseEntity.DeleteAt))
                    continue;

                var pi = typeof(T).GetProperty(name);
                if (pi == null) continue;

                var newValue = pi.GetValue(entity);
                if (newValue != null)
                {
                    entry.Property(name).CurrentValue = newValue;
                    entry.Property(name).IsModified = true;
                }
                else
                {
                    // null => no tocar (semántica de parcial)
                    entry.Property(name).IsModified = false;
                }
            }

            dbEntity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await entry.ReloadAsync(); // si hay valores generados por BD

            return dbEntity;
        }

    }
}
