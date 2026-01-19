using MyFlix.DAO.Data;
using MyFlix.DAO.Generic.Class;
using MyFlix.DAO.Models;

namespace MyFlix.DAO.Service
{
    public class RepositoryFilme : Repository<Filme, MyFlixDbContext>, IRepositoryFilme
    {
        public RepositoryFilme() : base() { }

        public RepositoryFilme(MyFlixDbContext context) : base(context) { }

    }
}
