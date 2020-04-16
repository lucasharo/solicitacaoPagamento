using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class GenericDados<T> where T : class
    {
        public T Get(int id)
        {
            var db = new DadosContext();

            return db.Set<T>().Find(id);
        }

        public DbSet<T> GetAll()
        {
            var db = new DadosContext();

            return db.Set<T>();
        }

        public T Insert(T Entidade)
        {
            var db = new DadosContext();

            db.Set<T>().Add(Entidade);

            db.SaveChanges();

            return Entidade;
        }

        public T Update(T Entidade)
        {
            var db = new DadosContext();

            db.Set<T>().Attach(Entidade);

            db.Entry(Entidade).State = EntityState.Modified;

            db.SaveChanges();

            return Entidade;
        }

        public void Delete(int id)
        {
            var db = new DadosContext();

            T Entidade = db.Set<T>().Find(id);

            db.Set<T>().Remove(Entidade);

            db.SaveChanges();
        }
    }
}
