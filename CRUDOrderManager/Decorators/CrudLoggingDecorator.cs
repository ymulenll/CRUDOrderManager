using Domain.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class CrudLoggingDecorator<TEntity> : ISave<TEntity>, IDelete<TEntity>, IRead<TEntity>
    {
        private readonly ISave<TEntity> decoratedSave;
        private readonly IDelete<TEntity> decoratedDelete;
        private readonly IRead<TEntity> decoratedRead;
        private readonly ILog log;

        public CrudLoggingDecorator(ISave<TEntity> decoratedSave, IDelete<TEntity> decoratedDelete, IRead<TEntity> decoratedRead, ILog log)
        {
            this.decoratedSave = decoratedSave;
            this.decoratedDelete = decoratedDelete;
            this.decoratedRead = decoratedRead;
            this.log = log;
        }

        public void Save(TEntity entity)
        {
            log.LogInfo($"Saving entity of type {typeof(TEntity).Name}");

            this.decoratedSave.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            log.LogInfo($"Deleting entity of type {typeof(TEntity).Name}");

            this.decoratedDelete.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.LogInfo($"Reading all entities of type {typeof(TEntity).Name}");

            return decoratedRead.ReadAll();
        }

        public TEntity ReadOne(int id)
        {
            log.LogInfo($"Reading entity of type {typeof(TEntity).Name} with id {id}");

            return decoratedRead.ReadOne(id);
        }
    }
}
