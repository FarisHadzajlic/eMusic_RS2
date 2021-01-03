using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IBaseService<T, TSearch>
    {
        Task<T> Insert(TInsert request);
        Task<T> Update(int ID, TUpdate request);
        Task<bool> Delete(int ID);
    }
}
