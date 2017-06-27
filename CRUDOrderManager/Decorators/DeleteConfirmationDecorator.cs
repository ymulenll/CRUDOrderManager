using Domain.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class DeleteConfirmationDecorator<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;

        private readonly IUserInteraction userInteraction;

        public DeleteConfirmationDecorator(ICreateReadUpdateDelete<TEntity> decoratedCrud, IUserInteraction userInteraction)
        {
            this.decoratedCrud = decoratedCrud;
            this.userInteraction = userInteraction;
        }

        public void Create(TEntity entity)
        {
            this.decoratedCrud.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            if (this.userInteraction.Confirm("Are you sure you want to delete de entry ?"))
            {
                decoratedCrud.Delete(entity);
            }
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return this.decoratedCrud.ReadAll();
        }

        public TEntity ReadOne(int id)
        {
            return this.decoratedCrud.ReadOne(id);
        }

        public void Update(TEntity entity)
        {
            this.decoratedCrud.Update(entity);
        }
    }
}
