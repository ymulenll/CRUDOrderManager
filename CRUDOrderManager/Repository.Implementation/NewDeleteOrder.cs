using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class NewDeleteOrder<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            // New Implementation
        }

        public IEnumerable<TEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
