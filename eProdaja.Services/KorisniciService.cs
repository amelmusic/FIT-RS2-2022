using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using eProdaja.Model;

namespace eProdaja.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, Database.Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        public KorisniciService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.Korisnici Insert(KorisniciInsertRequest insert)
        {

            if (insert.Password != insert.PasswordPotvrda)
            {
                throw new UserException("Password and confirmation must be the same");
            }

            var entity = base.Insert(insert);

            
            foreach(var ulogaId in insert.UlogeIdList)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.UlogaId = ulogaId;
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                Context.KorisniciUloges.Add(korisniciUloge);
            }

            Context.SaveChanges();

            return entity;
        }

        public override void BeforeInsert(KorisniciInsertRequest insert, Database.Korisnici entity)
        {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Password);
            base.BeforeInsert(insert, entity);
        }


        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override IQueryable<Database.Korisnici> AddFilter(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }

            if (!string.IsNullOrWhiteSpace(search?.NameFTS))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme.Contains(search.NameFTS) 
                    || x.Ime.Contains(search.NameFTS)
                    || x.Prezime.Contains(search.NameFTS));
            }

            return filteredQuery;
        }

        public override IQueryable<Database.Korisnici> AddInclude(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            if (search?.IncludeRoles == true)
            {
                 query = query.Include("KorisniciUloges.Uloga");
            }
            return query;
        }

        public Model.Korisnici Login(string username, string password)
        {
            var entity = Context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);
            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<Model.Korisnici>(entity);
        }
    }
}
