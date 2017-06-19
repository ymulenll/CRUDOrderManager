using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class EmptyCreateReadUpdateDelete<TEntity> : ICreateUpdate<TEntity>, IDelete<TEntity>, IRead<TEntity>
    {
        public void Create(TEntity entity)
        {
            
        }

        public void Delete(TEntity entity)
        {
            
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return new TEntity[0];
        }

        public TEntity ReadOne(int id)
        {
            return default(TEntity);
        }

        public void Update(TEntity entity)
        {
            
        }
    }
}
