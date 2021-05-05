using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Commands.Tarefa.Input
{
    public class AlterarTarefaCommand
    {
        [JsonIgnore] //precisa ser colocado exatamente em cima do item que vc nao quer que apareça (nesse caso, o Id)
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Realizador { get; set; }
        public double TempoEstimado { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public EStatus Status { get; set; }

        //ter um metodo para validar e notificar as inconsistencias
    }
}
