using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Dados { get; set; }
    }
}
