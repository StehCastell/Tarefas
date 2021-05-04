using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositories;
using Tarefas.Infra.Data.DataContexts;

namespace Tarefas.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public TarefaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Tarefa tarefa)
        {
            try
            {
                _parametros.Add("Titulo", tarefa.Titulo, DbType.String);
                _parametros.Add("Descricao", tarefa.Descricao, DbType.String);
                _parametros.Add("Observacao", tarefa.Observacao, DbType.String);
                _parametros.Add("Realizador", tarefa.Realizador, DbType.String);
                _parametros.Add("TempoEstimado", tarefa.TempoEstimado, DbType.Double);
                _parametros.Add("DataHoraInicio", tarefa.DataHoraInicio, DbType.DateTime);
                _parametros.Add("DataHoraFim", tarefa.DataHoraFim, DbType.DateTime);
                _parametros.Add("Status", tarefa.Status, DbType.Int16);

                string sql = @"INSERT INTO Tarefa (Titulo, Descricao, Observacao, Realizador, TempoEstimado, DataHoraInicio, DataHoraFim, Status) 
                              VALUES (@Titulo, @Descricao, @Observacao, @Realizador, @TempoEstimado, @DataHoraInicio, @DataHoraFim, @Status)";

                _dataContext.MySqlConnection.Execute(sql, _parametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
