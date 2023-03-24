using System.Linq.Expressions;
//Interface ekleyeceğiz
namespace FordApi.Data.Repository.Abstract;
//<TEntity> =>ben sana dışardan bir entity göndercem(ör:STAFF)
public interface IGenericRepository<TEntity> where TEntity : class
{
    //içerisine methodlarımızı yazıyoruz.
    //Bu methodlara görev atamaları yapmam gerekiyor.
    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Update(TEntity entity);
    void Remove(int id);
    void Insert(TEntity entity);
    IEnumerable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);   
}