using CoreMVC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TModel, TContext> : IEntityRepository<TModel>
        where TModel : class,IModel, new()
        where TContext : DbContext,new()
    {


        public void Add(TModel model)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(model);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TModel model)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(model);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public void Update(TModel  model)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(model);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TModel Get(Expression<Func<TModel, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TModel>().FirstOrDefault(filter);
            }
        }

        public List<TModel> GetAll(Expression<Func<TModel, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TModel>().ToList() : context.Set<TModel>().Where(filter).ToList();
            }
        }
    }

}
