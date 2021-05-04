using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Commands;
using Tarefas.Domain.Commands.Tarefa.Input;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Handlers;
using Tarefas.Domain.Interfaces.Repositories;
using Tarefas.Infra.Interfaces.Commands;

namespace Tarefas.Domain.Handlers
{
    public class TarefaHandler : ITarefaHandler
    {
        private readonly ITarefaRepository _repository;

        public TarefaHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarTarefaCommand command)
        {
            try
            {
                //fazer validação do command

                Tarefa tarefa = new Tarefa(
                    0,
                    command.Titulo,
                    command.Descricao,
                    command.Observacao,
                    command.Realizador,
                    command.TempoEstimado,
                    command.DataHoraInicio,
                    command.DataHoraFim,
                    command.Status);

                _repository.Inserir(tarefa);

                var retorno = new CommandResult(true, "Tarefa Cadastrada com Sucesso", new
                {
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    Observacao = tarefa.Observacao,
                    Realizador = tarefa.Realizador,
                    TempoEstimado = tarefa.TempoEstimado,
                    DataHoraInicio = tarefa.DataHoraInicio,
                    DataHoraFim = tarefa.DataHoraFim,
                    Status = tarefa.Status
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
