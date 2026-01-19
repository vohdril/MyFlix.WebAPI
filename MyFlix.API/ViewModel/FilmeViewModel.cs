using BaseProject.DAO.Models.Partial;
using MyFlix.DAO.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyFlix.API.ViewModel
{
    public class FilmeVM : GenericViewModel<MyFlix.DAO.Models.Filme, FilmeVM>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário incluir um título!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "É necessário incluir um gênero!")]
        public string Genero { get; set; }

        public DateTime AnoLancamento { get; set; }

        public int Nota { get; set; }

        public string Poster { get; set; }


        public bool StatusAssistido { get; set; }

        public DateTime DataCadastro { get; set; }


        public FilmeVM()
        : base()
        {

            DataCadastro = DateTime.Now;
            StatusAssistido = false;
        }

        public FilmeVM(Filme model)
            : base()
        {

        }


        public override FilmeVM Cast(Filme model)
        {
            return new FilmeVM()
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Genero = model.Genero,
                Nota = model.Nota,
                AnoLancamento = model.AnoLancamento,
                DataCadastro = model.DataCadastro,
                StatusAssistido = model.StatusAssistido,
                Poster = model.Poster
            };

        }


        public override Filme Cast(FilmeVM model)
        {
            return new Filme()
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Genero = model.Genero,
                Nota = model.Nota,
                AnoLancamento = model.AnoLancamento,
                DataCadastro = model.DataCadastro,
                StatusAssistido = model.StatusAssistido,
                Poster  = model.Poster
            };

        }
    }
}
