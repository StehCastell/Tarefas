using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tarefas.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public MySqlConnection MySqlConnection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                MySqlConnection = new MySqlConnection(appSettings.ConnectionString);
                MySqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (MySqlConnection.State != ConnectionState.Closed)
                    MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
