using MyFlix.DAO.Models;
using MyFlix.DAO.Service;
using MyFlix.DAO.Generic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using System.Text;
using MyFlix.Util;
using MyFlix.API.ViewModel;
using BaseProject.API.Util;
using MyFlix.API.Util;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net;
 
namespace MyFlix.API.Controllers
{
    //[Authorize]
    [AllowAnonymous]

    [Route("api/filmes")]
    public class FilmeController : CrudController<Filme, IServiceFilme, ViewModel.FilmeVM>
    {

        private readonly IServiceFilme _serviceFilme;

        public FilmeController(IServiceFilme serviceFilme)
                : base(serviceFilme)
        {
            this.DefaultNavigationMapping = "";
            _serviceFilme = serviceFilme;

        }

        /// <summary>
        /// Obtém todos os filmes cadastrados no sistema.
        /// </summary>
        /// <remarks>
        /// O metodo retorna um objeto JSON com duas proprieades: uma contagem total de filmes e a lista com todos os filmes
        /// </remarks>
        /// <returns>Objeto JSON com duas propriedades: total de filmes (int) e Lista de filmes (Filme).
        /// </returns>
        /// <response code="200">Lista de filmes encontrada com sucesso.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpGet(Order = -1)]
        public IActionResult Filmes()

        {
            return base.Listar(base.Service);

        }


        /// <summary>
        /// Obtém os filmes cadastrados no sistema que não foram assitidos (StatusAssistido == true).
        /// </summary>
        /// <remarks>
        /// O metodo retorna um objeto JSON com duas proprieades: uma contagem total de filmes e a lista os filmes
        /// </remarks>
        /// <returns>Objeto JSON com duas propriedades: total de filmes (int) e Lista de filmes (Filme).
        /// </returns>
        /// <response code="200">Lista de filmes encontrada com sucesso.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpGet("filmes-assistidos")]
        public IActionResult FilmesAssistidos()

        {
            List<Filme> filmes =
                base
                .Service
                .ObterTodos()
                .Where(_filme => _filme.StatusAssistido)
                .ToList();

            return this.CreateResponse(true, payload: new
            {
                total_encontrado = filmes.Count,
                resultados = filmes.Select(x => ViewModel.Cast(x))
            });


        }

        /// <summary>
        /// Obtém os filmes cadastrados no sistema que não foram assitidos (StatusAssistido == false).
        /// </summary>
        /// <remarks>
        /// O metodo retorna um objeto JSON com duas proprieades: uma contagem total de filmes e a lista com os filmes
        /// </remarks>
        /// <returns>Objeto JSON com duas propriedades: total de filmes (int) e Lista de filmes (Filme).
        /// </returns>
        /// <response code="200">Lista de filmes encontrada com sucesso.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpGet("filmes-para-assistir")]
        public IActionResult FilmesParaAssistir()

        {
            List<Filme> filmes =
                base
                .Service
                .ObterTodos()
                .Where(_filme => !_filme.StatusAssistido)
                .ToList();

            return this.CreateResponse(true, payload: new
            {
                total_encontrado = filmes.Count,
                resultados = filmes.Select(x => ViewModel.Cast(x))
            });


        }

        /// <summary>
        /// Faz a busca de um filme no sistema.
        /// </summary>
        /// <remarks>
        /// O metodo realiza a busca de um novo filme no sistema usando seu ID como referência. Alguns campos retornados não possuem formatação ou pontuação.
        /// </remarks>
        /// <returns>Objeto do tipo "Filme".
        /// </returns>
        /// <response code="200">Filme encontrado com sucesso.
        /// </response>       
        /// <response code="404">Filme não encontrado no sistema.
        /// </response>
        /// <response code="401">Requisição não autorizada pelo servidor.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>
        [HttpGet("{id:int}")]
        public IActionResult Filmes([FromRoute] int id)
        {
            return base.Visualizar(id, base.Service);

        }

        /// <summary>
        /// Realiza o cadastro de um novo filme no sistema.
        /// </summary>
        /// <response code="200">Filme cadastrado com sucesso.
        /// </response>       
        /// <response code="400">Erro em um ou mais campos de cadastro.
        /// </response>
        ///     /// <response code="401">Requisição não autorizada pelo servidor.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpPost]
        public IActionResult Filmes([FromBody] FilmeVM model)
        {

            bool sucesso = base.Service.Adicionar(model.Cast(model));
            return this.CreateResponse(
                sucesso,
                successMessage: sucesso ? "Sucesso ao adicionar as informações!" : null,
                errorMessage: !sucesso ? "Erro ao adicionar as informações, verifique as informações inseridas e tente novamente mais tarde!" : null
                );
        }


        /// <summary>
        /// Realiza a atualização das informações de um filme no sistema
        /// </summary>
        /// <response code="200">Filme atualizado com sucesso.
        /// </response>       
        /// <response code="400">Erro em um ou mais campos de cadastro.
        /// </response>
       /// <response code="401">Requisição não autorizada pelo servidor.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpPut("{id:int}")]
        public IActionResult Filmes([FromRoute] int id, [FromBody] FilmeVM model)
        {

            model.Id = id;

            return base.Editar(id, model, base.Service);


        }

        /// <summary>
        /// Faz a exclusão de um filme no sistema.
        /// </summary>
        /// <remarks>
        /// O metodo realiza a exclusão de um filme no sistema usando seu ID como referência
        /// </remarks>
        /// <response code="200">Filme excluido com sucesso!.
        /// </response>       
        /// <response code="404">Filme não encontrado no sistema.
        /// </response>
        /// <response code="401">Requisição não autorizada pelo servidor.
        /// </response>
        /// <response code="500">Erro interno no servidor.
        /// </response>

        [HttpDelete("{id:int}")]

        public IActionResult _Filmes([FromRoute] int id)
        {
            return base.Excluir(id);


        }
    }



}