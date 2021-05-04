using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public string Realizador { get; private set; }
        public double TempoEstimado { get; private set; }
        public DateTime? DataHoraInicio { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public EStatus Status { get; private set; }

        public Tarefa(int id, string titulo, string descricao, string observacao, string realizador, double tempoEstimado, 
                      DateTime? dataHoraInicio, DateTime? dataHoraFim, EStatus status)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Observacao = observacao;
            Realizador = realizador;
            TempoEstimado = tempoEstimado;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            Status = status;
        }
    }
}
