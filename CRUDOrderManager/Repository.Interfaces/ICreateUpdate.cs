using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICreateUpdate<TEntity>
    {
        void Create(TEntity entity);

        void Update(TEntity entity);
    }
}
