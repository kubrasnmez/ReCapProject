
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class ve interface'leri belirli bir isim uzayına bırakıyouz ki kolayca bulabişlmek için

    //Generic Constraint - Generic kısıt
    //class referans tip olabilir.
    // IEntity : IEntity olabilir veya IENtityden implemente eden bir nesne olabilir.
    //new() : new'lenebilir


    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
