using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YSKProje.UdemyJwtProje.Entities.Interfaces;

namespace YSK.UdemyJwtProje.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity: class,ITable,new()
    {
        //GenericDaldan Kopyaladım. filterlı olanları almıyoruz.
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
