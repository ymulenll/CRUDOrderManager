using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICreateReadUpdateDelete<TEntity>
    {
        void Create(TEntity entity);

        TEntity ReadOne(int id);

        IEnumerable<TEntity> ReadAll();

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
