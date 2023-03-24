using FordApi.Data.Repository.Abstract;
namespace FordApi.Data.UnitOfWork.Abstract;
//IDisposable ==> Unit of work işi bittiği zaman kendisi oto olarak silinsin
public interface IUnitOfWork : IDisposable
{
    //Bu neden??
    IGenericRepository<Staff> StaffRepository { get; }
    void CompleteWithTransaction();
    void Complete();
}