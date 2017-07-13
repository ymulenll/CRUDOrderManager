using Domain.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class DeleteConfirmationDecorator<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decoratedCrud;

        private readonly IUserInteraction userInteraction;

        public DeleteConfirmationDecorator(IDelete<TEntity> decoratedCrud, IUserInteraction userInteraction)
        {
            this.decoratedCrud = decoratedCrud;
            this.userInteraction = userInteraction;
        }

        public void Delete(TEntity entity)
        {
            if (this.userInteraction.Confirm("Are you sure you want to delete de entry ?"))
            {
                decoratedCrud.Delete(entity);
            }
        }
    }
}
