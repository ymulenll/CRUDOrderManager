using Domain.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class CrudLoggingDecorator<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;
        private readonly ILog log;

        public CrudLoggingDecorator(ICreateReadUpdateDelete<TEntity> decoratedCrud, ILog log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.LogInfo($"Creating entity of type {typeof(TEntity).Name}");

            this.decoratedCrud.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            log.LogInfo($"Deleting entity of type {typeof(TEntity).Name}");

            this.decoratedCrud.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.LogInfo($"Reading all entities of type {typeof(TEntity).Name}");

            return decoratedCrud.ReadAll();
        }

        public TEntity ReadOne(int id)
        {
            log.LogInfo($"Reading entity of type {typeof(TEntity).Name} with id {id}");

            return decoratedCrud.ReadOne(id);
        }

        public void Update(TEntity entity)
        {
            log.LogInfo($"Updating entity of type {typeof(TEntity).Name}");

            this.decoratedCrud.Update(entity);
        }
    }
}
