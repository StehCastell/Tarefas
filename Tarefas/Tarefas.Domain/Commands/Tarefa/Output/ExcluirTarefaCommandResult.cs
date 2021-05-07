using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Interfaces.Commands;

namespace Tarefas.Domain.Commands.Tarefa.Output
{
    public class ExcluirTarefaCommandResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }

        public ExcluirTarefaCommandResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}
