using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IService<T, TSearch> where T : class where TSearch : class
    {
        IEnumerable<T> Get(TSearch search = null);
        T GetById(int id);
    }
}
