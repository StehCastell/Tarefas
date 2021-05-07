using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Commands;
using Tarefas.Domain.Commands.Tarefa.Input;
using Tarefas.Domain.Commands.Tarefa.Output;
using Tarefas.Domain.Interfaces.Handlers;
using Tarefas.Domain.Interfaces.Repositories;
using Tarefas.Domain.Queries.Tarefa;

namespace Tarefas.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaHandler _handler;
        private readonly ITarefaRepository _repository;

        public TarefaController(ITarefaHandler handler, ITarefaRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        /// <summary>
        /// Incluir Tarefa 
        /// </summary>                
        /// <remarks><h2><b>Incluir nova Tarefa na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/tarefas")]
        [ProducesResponseType(typeof(AdicionarTarefaCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AdicionarTarefaCommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AdicionarTarefaCommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(AdicionarTarefaCommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirTarefa([FromBody] AdicionarTarefaCommand command) 
        {
            var retorno = _handler.Handle(command);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Alterar Tarefa 
        /// </summary>                
        /// <remarks><h2><b>Alterar uma Tarefa na base de dados.</b></h2></remarks>
        /// <param name="id">Número de identificação da tarefa</param>
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/tarefas/{id}")]
        [ProducesResponseType(typeof(AlterarTarefaCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AlterarTarefaCommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AlterarTarefaCommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(AlterarTarefaCommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult AlterarTarefa(int id,[FromBody] AlterarTarefaCommand command)
        {
            command.Id = id;
            var retorno = _handler.Handle(command);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Excluir Tarefa 
        /// </summary>                
        /// <remarks><h2><b>Excluir uma Tarefa na base de dados.</b></h2></remarks>
        /// <param name="id">Número de identificação da tarefa</param>
        /// <response code="200">OK Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/tarefas/{id}")]
        [ProducesResponseType(typeof(ExcluirTarefaCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExcluirTarefaCommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ExcluirTarefaCommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ExcluirTarefa(int id)
        {
            var retorno = _handler.Handle(id);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Consultar Tarefa por Id
        /// </summary>                
        /// <remarks><h2><b>Consultar uma Tarefa por Id na base de dados.</b></h2></remarks>
        /// <param name="id">Número de identificação da tarefa</param>
        /// <response code="200">OK Request</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/tarefas/{id}")]
        [ProducesResponseType(typeof(TarefaQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TarefaQueryResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TarefaQueryResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ConsultarPorId(int id)
        {
            var retorno = _repository.ConsultarPorId(id);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Consultar Todas as Tarefas
        /// </summary>                
        /// <remarks><h2><b>Consultar todas as Tarefas na base de dados.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/tarefas")]
        [ProducesResponseType(typeof(List<TarefaQueryResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<TarefaQueryResult>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<TarefaQueryResult>), StatusCodes.Status500InternalServerError)]
        public IActionResult Listar()
        {
            var retorno = _repository.Listar();
            return StatusCode(200, retorno);
        }
    }
}
