using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class Service<TEntity> where TEntity : Entity
    {
        protected ISession _session;

        public Service()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public virtual void Delete(TEntity entity)
        {
            this._session.Delete(entity);
        }

        public virtual TEntity Get(int id)
        {
            return this._session.Get<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }
        public virtual TEntity Save(TEntity entity)
        {
            try
            {
                _session.SaveOrUpdate(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }
    }
}
