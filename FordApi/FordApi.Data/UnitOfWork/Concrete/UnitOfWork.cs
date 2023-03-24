using FordApi.Data.Context;
using FordApi.Data.Repository.Abstract;
using FordApi.Data.Repository.Concrete;
using FordApi.Data.UnitOfWork.Abstract;
namespace FordApi.Data.UnitOfWork.Concrete;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private bool disposed;
    public IGenericRepository<Staff> StaffRepository { get; private set; }
    public UnitOfWork(AppDbContext context)
    {
        this.context = context; 
        StaffRepository = new GenericRepository<Staff>(context); //context nesnesini GenericRepoya aktarıyorum.
    }
    public void CompleteWithTransaction()
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
                context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging                    
                dbContextTransaction.Rollback();
            }
        }
    }
    public void Complete()
    {
        context.SaveChanges(); //Transiction burda biter
    }
    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}
