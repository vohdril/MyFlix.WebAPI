using MyFlix.DAO.Models;
using System.Linq.Expressions;

namespace MyFlix.DAO.Service
{
    public class ServiceFilme : IServiceFilme
    {
        private readonly IRepositoryFilme _repositoryFilme;

        public ServiceFilme(IRepositoryFilme repositoryFilme)
        {
            _repositoryFilme = repositoryFilme;
        }

        public Filme ObterPorId(int id, string includeProperties = "")
        {
            return _repositoryFilme.FirstOrDefault(x => x.Id == id, includeProperties);
        }

        public Filme[] ObterTodos(string includeProperties = "", bool noTracking = true)
        {
            return _repositoryFilme.Get(includeProperties: includeProperties, noTracking: noTracking);
        }

        public bool Adicionar(Filme entity)
        {
            return _repositoryFilme.Insert(entity);
        }

        public bool Editar(Filme entity)
        {
            return _repositoryFilme.Update(entity);
        }

        public bool Deletar(int id)
        {
            return _repositoryFilme.Delete(id);
        }

        public bool Existe(int id)
        {
            return _repositoryFilme.Exists(x => x.Id == id);
        }

    }
}
