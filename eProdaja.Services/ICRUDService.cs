using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        T Insert(TInsert insert);

        T Update(int id, TUpdate update);
    }
}
