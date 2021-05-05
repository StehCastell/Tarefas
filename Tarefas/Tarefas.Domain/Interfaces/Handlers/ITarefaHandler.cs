using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Commands.Tarefa.Input;
using Tarefas.Infra.Interfaces.Commands;

namespace Tarefas.Domain.Interfaces.Handlers
{
    public interface ITarefaHandler
    {
        ICommandResult Handle(AdicionarTarefaCommand command);
        ICommandResult Handle(AlterarTarefaCommand command);
        ICommandResult Handle(int id);

    }
}
