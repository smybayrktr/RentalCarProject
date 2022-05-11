﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entities
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Tüm T leri listeler.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
