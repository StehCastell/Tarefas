using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Queries.Tarefa;

namespace Tarefas.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void Inserir(Tarefa tarefa);
        void Alterar(Tarefa tarefa);
        void Excluir(int id);
        TarefaQueryResult ConsultarPorId(int id);
        List<TarefaQueryResult> Listar();
    }
}
