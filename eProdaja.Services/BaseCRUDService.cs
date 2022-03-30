using AutoMapper;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> 
        : BaseService<T, TDb, TSearch> , ICRUDService<T, TSearch, TInsert, TUpdate>
            where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(eProdajaContext context, IMapper mapper)
        :base(context, mapper){}

        public T Insert(TInsert insert)
        {
            var set = Context.Set<TDb>();

            TDb entity = Mapper.Map<TDb>(insert);

            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<T>(entity);
        }

        public T Update(int id, TUpdate update)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
            {
                Mapper.Map(update, entity);
            }
            else
            {
                return null;
            }

            Context.SaveChanges();

            return Mapper.Map<T>(entity);

        }
    }
}
