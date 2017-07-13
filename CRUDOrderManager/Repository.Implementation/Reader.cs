using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Reader<TEntity> : IRead<TEntity>
    {
        public TEntity ReadOne(int id)
        {
            return default(TEntity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return new List<TEntity>();
        }
    }
}
