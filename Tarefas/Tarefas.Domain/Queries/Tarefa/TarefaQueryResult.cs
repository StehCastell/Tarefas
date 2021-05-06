using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Queries.Tarefa
{
    public class TarefaQueryResult
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Realizador { get; set; }
        public double TempoEstimado { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public EStatus Status { get; set; }
    }
}
