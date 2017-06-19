using Domain.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class CrudLoggingDecorator<TEntity> : ICreateReadUpdate<TEntity>, IDelete<TEntity>
    {
        private readonly ICreateReadUpdate<TEntity> decoratedCru;
        private readonly IDelete<TEntity> decoratedDelete;
        private readonly ILog log;

        public CrudLoggingDecorator(ICreateReadUpdate<TEntity> decoratedCru, IDelete<TEntity> decoratedDelete, ILog log)
        {
            this.decoratedCru = decoratedCru;
            this.decoratedDelete = decoratedDelete;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.LogInfo($"Creating entity of type {typeof(TEntity).Name}");

            this.decoratedCru.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            log.LogInfo($"Deleting entity of type {typeof(TEntity).Name}");

            this.decoratedDelete.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.LogInfo($"Reading all entities of type {typeof(TEntity).Name}");

            return decoratedCru.ReadAll();
        }

        public TEntity ReadOne(int id)
        {
            log.LogInfo($"Reading entity of type {typeof(TEntity).Name} with id {id}");

            return decoratedCru.ReadOne(id);
        }

        public void Update(TEntity entity)
        {
            log.LogInfo($"Updating entity of type {typeof(TEntity).Name}");
        }
    }
}
