using MySql.Data.MySqlClient;

namespace InvastigationGame.MySQL
{
    public class SQLServer
    {
        private string SqlString = "Server=localhost;Database=invastigation_game;User=root;Password=''";
        public MySqlConnection connection = null;
        public SQLServer()
        {

        }

        public MySqlConnection OpenConnection()
        {
            if (this.connection is null)
            {
                this.connection = new MySqlConnection(SqlString);
            }

            if (this.connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return this.connection;
        }

        public void CloseConnection()
        {
            if (this.connection != null && this.connection.State == System.Data.ConnectionState.Open)
            {
                this.connection.Close();
            }
        }
    }
}
