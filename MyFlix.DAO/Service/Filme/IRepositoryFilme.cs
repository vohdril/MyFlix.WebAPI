using MyFlix.DAO.Data;
using MyFlix.DAO.Generic.Interface;
using MyFlix.DAO.Models;


namespace MyFlix.DAO.Service
{
    public interface IRepositoryFilme : IRepository<Filme, MyFlixDbContext>
    {

    }
}
