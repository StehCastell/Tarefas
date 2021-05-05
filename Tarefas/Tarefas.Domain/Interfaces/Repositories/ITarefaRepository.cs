using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void Inserir(Tarefa tarefa);
        void Alterar(Tarefa tarefa);
        void Excluir(int id);
    }
}
