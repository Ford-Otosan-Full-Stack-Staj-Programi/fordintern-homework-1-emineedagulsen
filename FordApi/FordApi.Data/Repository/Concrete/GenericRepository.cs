using FordApi.Data.Context;
using FordApi.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace FordApi.Data.Repository.Concrete;

//TEntity değeri al sonra miras al IGenericRepository 'den 
//yine bir TEntity değeri alcam yalnız burdaki şartım TEntity bir class olcak
//Ben GenericRepository sınıfına kalıtsal yolla almaya çalıştığım IGenericRepository isimle Interface'in
//Burda bu method özelliklerini kullanmak istiyorsam implement etmem gerekiyor.
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext context; //AppDbContext classından context adında sadece okunabilir bir object oluşturdum sadece bu sınıfta oluşturulabilir.
    private DbSet<TEntity> entities; //DbSet türünde içine TEntity değeri alan bir file oluşturdum. 
   
    //şimdi bu entities file'a değer atamaları yapcaz.
    //Consturctor method oluştur.( ctor 2 defa tab)
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        this.entities = this.context.Set<TEntity>(); //contextten gelen değeri entites'e ata.
        //Tümü için tek tek CRUD işlemleri gerçekleştirmek yerine bu yapı üzerinden gerçekleştircem.
    }
    //Implement işlemi
    public List<TEntity> GetAll()
    {
        return entities.ToList();
    }
    public TEntity GetById(int entityId)
    {
        return entities.Find(entityId);
    }
    void IGenericRepository<TEntity>.Update(TEntity entity)
    {
        entities.Update(entity);
    }
    public void Insert(TEntity entity)
    {
        entities.Add(entity);
    }
    public void Remove(int id)
    {
        var entity = GetById(id);
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            entities.Remove(entity);
        }
    }
    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return entities.Where(predicate).ToList();
   
    }
}