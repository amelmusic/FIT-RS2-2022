
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IJediniceMjereService
    {
        IEnumerable<JediniceMjere> Get();
        JediniceMjere GetById(int id);
    }
}
