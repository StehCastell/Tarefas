using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Commands;
using Tarefas.Domain.Commands.Tarefa.Input;
using Tarefas.Domain.Interfaces.Handlers;

namespace Tarefas.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaHandler _handler;

        public TarefaController(ITarefaHandler handler)
        {
            _handler = handler;
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
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirTarefa([FromBody] AdicionarTarefaCommand command) 
        {
            var retorno = _handler.Handle(command);
            return StatusCode(200, retorno);
        }
    }
}
