﻿using System.Data.Entity;

namespace DocumentManagementDAL
{
  public class BaseRepository<TEntity> where TEntity : class
  {
    internal DMSEntities context;
    internal DbSet<TEntity> dbSet;

    public BaseRepository(DMSEntities context)
    {
      this.context = context;
      this.dbSet = context.Set<TEntity>();
    }

    public virtual TEntity GetByID(object id)
    {
      return dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
      dbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
      TEntity entityToDelete = dbSet.Find(id);
      Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
      if (context.Entry(entityToDelete).State == EntityState.Detached)
      {
        dbSet.Attach(entityToDelete);
      }
      dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
      dbSet.Attach(entityToUpdate);
      context.Entry(entityToUpdate).State = EntityState.Modified;
    }
  }
}
