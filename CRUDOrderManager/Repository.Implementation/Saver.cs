using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Saver<TEntity> : ISave<TEntity>
    {
        public void Save(TEntity entity)
        {

        }
    }
}
