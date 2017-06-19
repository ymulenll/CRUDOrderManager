using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class ReadCachingDecorator<TEntity> : IRead<TEntity>
    {
        private readonly IRead<TEntity> decoratedRead;

        private TEntity cachedEntity;
        private IEnumerable<TEntity> cachedEntities;

        public ReadCachingDecorator(IRead<TEntity> decoratedRead)
        {
            this.decoratedRead = decoratedRead;
        }

        public TEntity ReadOne(int id)
        {
            if (cachedEntity == null)
            {
                cachedEntity = decoratedRead.ReadOne(id);
            }
            return cachedEntity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (cachedEntities == null)
            {
                cachedEntities = decoratedRead.ReadAll();
            }

            return cachedEntities;
        }
    }
}
