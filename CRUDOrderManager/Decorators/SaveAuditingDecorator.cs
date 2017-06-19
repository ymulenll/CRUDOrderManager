using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decorators
{
    public class SaveAuditingDecorator<TEntity> : ISave<TEntity>
    {
        private readonly ISave<TEntity> decoratedSave;
        private readonly ISave<AuditInfo> auditSave;

        public SaveAuditingDecorator(ISave<TEntity> decoratedSave, ISave<AuditInfo> auditSave)
        {
            this.decoratedSave = decoratedSave;
            this.auditSave = auditSave;
        }

        public void Save(TEntity entity)
        {
            decoratedSave.Save(entity);
            var auditInfo = new AuditInfo
            {
                UserName = Thread.CurrentPrincipal.Identity.Name,
                TimeStamp = DateTime.Now
            };

            auditSave.Save(auditInfo);
        }
    }
}
